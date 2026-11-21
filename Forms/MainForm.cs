using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KeyEventLogger.Enums;
using KeyEventLogger.Models;
using KeyEventLogger.Services;

namespace KeyEventLogger.Forms
{
    public partial class MainForm : Form
    {
        private readonly KeyLoggerService _loggerService;
        private readonly StatisticsService _statisticsService;
        private readonly FileExportService _exportService;

        private bool _isFiltered = false;

        public MainForm()
        {
            InitializeComponent();

            _loggerService = new KeyLoggerService();
            _statisticsService = new StatisticsService();
            _exportService = new FileExportService();

            InitializeDataGrid();
            BindEvents();

            // Başlangıçta kaydı aktif et
            _loggerService.Start();
            UpdateStatusUI(LoggingStatus.Active);
            UpdateStatistics();
        }

        private void InitializeDataGrid()
        {
            dgvLogs.Columns.Clear();

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                Width = 55,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTime",
                HeaderText = "Zaman Damgası",
                Width = 175,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colType",
                HeaderText = "Olay Türü",
                Width = 95,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colKey",
                HeaderText = "Tuş Adı",
                Width = 120
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCode",
                HeaderText = "Tuş Kodu",
                Width = 90,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMod",
                HeaderText = "Değiştirici Tuşlar",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void BindEvents()
        {
            // Klavye olayları (KeyPreview = true sayesinde tüm formda yakalanır)
            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
            KeyPress += MainForm_KeyPress;

            // Servis olayları
            _loggerService.OnKeyLogged += LoggerService_OnKeyLogged;
            _loggerService.OnStatusChanged += UpdateStatusUI;
            _loggerService.OnLogsCleared += LoggerService_OnLogsCleared;

            // Buton olayları
            btnStart.Click += (s, e) => _loggerService.Start();
            btnStop.Click += (s, e) => _loggerService.Stop();
            btnClear.Click += (s, e) =>
            {
                if (MessageBox.Show("Tüm kayıtları ve istatistikleri temizlemek istediğinize emin misiniz?",
                    "Kayıtları Temizle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _loggerService.Clear();
                }
            };

            btnExportTxt.Click += BtnExportTxt_Click;
            btnExportCsv.Click += BtnExportCsv_Click;

            // Filtreleme butonları
            btnApplyFilter.Click += BtnApplyFilter_Click;
            btnResetFilter.Click += BtnResetFilter_Click;

            // Filtre başlangıç seçimleri
            cmbFilterType.SelectedIndex = 0;
            dtpStartTime.Value = DateTime.Now.AddHours(-1);
            dtpEndTime.Value = DateTime.Now.AddHours(1);
        }

        private void MainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            // Altın tuşlar veya form kontrolleri için
            string modifiers = GetModifiersText(e.Modifiers);
            _loggerService.RecordEvent(KeyEventType.KeyDown, e.KeyCode.ToString(), e.KeyValue, modifiers);
        }

        private void MainForm_KeyUp(object? sender, KeyEventArgs e)
        {
            string modifiers = GetModifiersText(e.Modifiers);
            _loggerService.RecordEvent(KeyEventType.KeyUp, e.KeyCode.ToString(), e.KeyValue, modifiers);
        }

        private void MainForm_KeyPress(object? sender, KeyPressEventArgs e)
        {
            string keyDisplay = char.IsControl(e.KeyChar) ? $"Ctrl-0x{(int)e.KeyChar:X2}" : e.KeyChar.ToString();
            _loggerService.RecordEvent(KeyEventType.KeyPress, keyDisplay, (int)e.KeyChar, "Yok");
        }

        private static string GetModifiersText(Keys modifiers)
        {
            if (modifiers == Keys.None) return "Yok";

            List<string> list = new List<string>();
            if ((modifiers & Keys.Control) == Keys.Control) list.Add("Ctrl");
            if ((modifiers & Keys.Shift) == Keys.Shift) list.Add("Shift");
            if ((modifiers & Keys.Alt) == Keys.Alt) list.Add("Alt");

            return list.Count > 0 ? string.Join("+", list) : "Yok";
        }

        private void LoggerService_OnKeyLogged(KeyLogEntry entry)
        {
            if (_isFiltered) return; // Filtre aktifken doğrudan grid'e ekleme yapmayıp filtreyi koru

            AddEntryToGrid(entry);
            UpdateStatistics();
        }

        private void AddEntryToGrid(KeyLogEntry entry)
        {
            int rowIndex = dgvLogs.Rows.Add(
                entry.Id,
                entry.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                entry.EventType.ToString(),
                entry.KeyName,
                entry.KeyCode,
                entry.Modifiers
            );

            // Renklendirme
            DataGridViewRow row = dgvLogs.Rows[rowIndex];
            if (entry.EventType == KeyEventType.KeyDown)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            }
            else if (entry.EventType == KeyEventType.KeyUp)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(254, 252, 232);
            }

            if (chkAutoScroll.Checked && dgvLogs.Rows.Count > 0)
            {
                dgvLogs.FirstDisplayedScrollingRowIndex = dgvLogs.Rows.Count - 1;
            }

            lblRecordCountStatus.Text = $"Listelenen: {dgvLogs.Rows.Count} olay";
        }

        private void LoggerService_OnLogsCleared()
        {
            dgvLogs.Rows.Clear();
            txtInputArea.Clear();
            UpdateStatistics();
            lblRecordCountStatus.Text = "Listelenen: 0 olay";
        }

        private void UpdateStatusUI(LoggingStatus status)
        {
            if (status == LoggingStatus.Active)
            {
                lblStatusBadge.Text = "● KAYIT AKTİF - Dinleniyor";
                lblStatusBadge.BackColor = Color.FromArgb(22, 163, 74); // Yeşil
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                lblStatusBadge.Text = "■ KAYIT DURDURULDU";
                lblStatusBadge.BackColor = Color.FromArgb(100, 116, 139); // Gri / Kırmızımsı
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void UpdateStatistics()
        {
            var logs = _loggerService.GetAllLogs();
            var summary = _statisticsService.GetEventSummary(logs);
            var topKeys = _statisticsService.GetTopKeys(logs, 6);

            lblTotalEvents.Text = $"Toplam Olay : {logs.Count}";
            lblKeyDowns.Text   = $"KeyDown      : {summary.totalDown}";
            lblKeyUps.Text     = $"KeyUp        : {summary.totalUp}";
            lblUniqueKeys.Text = $"Farklı Tuş   : {summary.uniqueKeys}";

            lstTopKeys.Items.Clear();
            if (topKeys.Count == 0)
            {
                lstTopKeys.Items.Add("(Henüz basım yok)");
            }
            else
            {
                foreach (var stat in topKeys)
                {
                    lstTopKeys.Items.Add(stat.ToString());
                }
            }
        }

        private void BtnExportTxt_Click(object? sender, EventArgs e)
        {
            var logs = _loggerService.GetAllLogs();
            if (logs.Count == 0)
            {
                MessageBox.Show("Kaydedilecek herhangi bir tuş olayı bulunmamaktadır.",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Metin Belgesi (*.txt)|*.txt",
                FileName = $"KeyEventLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt",
                Title = "Tuş Olaylarını TXT Olarak Kaydet"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (_exportService.ExportToTxt(sfd.FileName, logs))
                {
                    MessageBox.Show($"Kayıtlar başarıyla dosyaya kaydedildi:\n{sfd.FileName}",
                        "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Dosya kaydedilirken bir hata oluştu.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnExportCsv_Click(object? sender, EventArgs e)
        {
            var logs = _loggerService.GetAllLogs();
            if (logs.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak herhangi bir tuş olayı bulunmamaktadır.",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV Dosyası (*.csv)|*.csv",
                FileName = $"KeyEventLog_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                Title = "Tuş Olaylarını CSV Olarak Dışa Aktar"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (_exportService.ExportToCsv(sfd.FileName, logs))
                {
                    MessageBox.Show($"Kayıtlar CSV olarak başarıyla aktarıldı:\n{sfd.FileName}",
                        "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("CSV dosyası oluşturulurken bir hata oluştu.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnApplyFilter_Click(object? sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            KeyEventType? typeFilter = cmbFilterType.SelectedIndex switch
            {
                1 => KeyEventType.KeyDown,
                2 => KeyEventType.KeyUp,
                3 => KeyEventType.KeyPress,
                _ => null
            };

            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;

            var filteredLogs = _loggerService.FilterLogs(search, typeFilter, startTime, endTime);

            _isFiltered = true;
            dgvLogs.Rows.Clear();
            foreach (var entry in filteredLogs)
            {
                AddEntryToGrid(entry);
            }

            lblRecordCountStatus.Text = $"Filtrelenen: {filteredLogs.Count} / {_loggerService.TotalCount} olay";
        }

        private void BtnResetFilter_Click(object? sender, EventArgs e)
        {
            _isFiltered = false;
            txtSearch.Clear();
            cmbFilterType.SelectedIndex = 0;

            dgvLogs.Rows.Clear();
            foreach (var entry in _loggerService.GetAllLogs())
            {
                AddEntryToGrid(entry);
            }

            lblRecordCountStatus.Text = $"Listelenen: {_loggerService.TotalCount} olay";
        }
    }
}
