using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using KeyEventLogger.Enums;
using KeyEventLogger.Forms;
using KeyEventLogger.Models;

namespace KeyEventLogger
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--generate-screenshots")
            {
                GenerateScreenshots();
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        private static void GenerateScreenshots()
        {
            string screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "screenshots");
            Directory.CreateDirectory(screenshotsDir);

            ApplicationConfiguration.Initialize();

            // 1. Ekran Görüntüsü: Aktif Kayıt ve Tuş İstatistikleri Ekranı
            using (MainForm form1 = new MainForm())
            {
                form1.Show();
                form1.Size = new Size(1060, 628);

                // Gerçekçi klavye olayları simüle et
                var serviceField = typeof(MainForm).GetField("_loggerService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (serviceField?.GetValue(form1) is Services.KeyLoggerService service)
                {
                    // Merhaba Dünya yazımı simülasyonu
                    string sampleText = "Merhaba Dunya! YMH219 Key Event Logger Test";
                    foreach (char c in sampleText)
                    {
                        service.RecordEvent(KeyEventType.KeyDown, c.ToString().ToUpper(), (int)c, "Yok");
                        service.RecordEvent(KeyEventType.KeyPress, c.ToString(), (int)c, "Yok");
                        service.RecordEvent(KeyEventType.KeyUp, c.ToString().ToUpper(), (int)c, "Yok");
                    }

                    // Bazı kontrol tuşları
                    service.RecordEvent(KeyEventType.KeyDown, "Space", 32, "Yok");
                    service.RecordEvent(KeyEventType.KeyUp, "Space", 32, "Yok");
                    service.RecordEvent(KeyEventType.KeyDown, "Return", 13, "Yok");
                    service.RecordEvent(KeyEventType.KeyUp, "Return", 13, "Yok");
                    service.RecordEvent(KeyEventType.KeyDown, "S", 83, "Ctrl");
                    service.RecordEvent(KeyEventType.KeyUp, "S", 83, "Ctrl");
                }

                Application.DoEvents();
                Thread.Sleep(200);

                using (Bitmap bmp = new Bitmap(form1.Width, form1.Height))
                {
                    form1.DrawToBitmap(bmp, new Rectangle(0, 0, form1.Width, form1.Height));
                    bmp.Save(Path.Combine(screenshotsDir, "dashboard.png"), ImageFormat.Png);
                }

                form1.Close();
            }

            // 2. Ekran Görüntüsü: Filtrelenmiş Kayıtlar Görünümü
            using (MainForm form2 = new MainForm())
            {
                form2.Show();
                form2.Size = new Size(1060, 628);

                var serviceField = typeof(MainForm).GetField("_loggerService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (serviceField?.GetValue(form2) is Services.KeyLoggerService service)
                {
                    string sampleText = "NESNE TABANLI PROGRAMLAMA 2026";
                    foreach (char c in sampleText)
                    {
                        service.RecordEvent(KeyEventType.KeyDown, c.ToString(), (int)c, "Yok");
                        service.RecordEvent(KeyEventType.KeyUp, c.ToString(), (int)c, "Yok");
                    }
                    service.RecordEvent(KeyEventType.KeyDown, "Enter", 13, "Yok");
                    service.RecordEvent(KeyEventType.KeyUp, "Enter", 13, "Yok");
                    service.RecordEvent(KeyEventType.KeyDown, "ShiftKey", 16, "Shift");
                    service.RecordEvent(KeyEventType.KeyUp, "ShiftKey", 16, "Shift");

                    // Arama kutusuna filtre uygula
                    var searchBox = form2.Controls.Find("txtSearch", true)[0] as TextBox;
                    if (searchBox != null) searchBox.Text = "Shift";

                    var btnApply = form2.Controls.Find("btnApplyFilter", true)[0] as Button;
                    btnApply?.PerformClick();
                }

                Application.DoEvents();
                Thread.Sleep(200);

                using (Bitmap bmp = new Bitmap(form2.Width, form2.Height))
                {
                    form2.DrawToBitmap(bmp, new Rectangle(0, 0, form2.Width, form2.Height));
                    bmp.Save(Path.Combine(screenshotsDir, "filtering.png"), ImageFormat.Png);
                }

                form2.Close();
            }

            Console.WriteLine("KeyEventLogger ekran görüntüleri başarıyla üretildi: " + screenshotsDir);
        }
    }
}
