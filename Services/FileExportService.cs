using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using KeyEventLogger.Models;

namespace KeyEventLogger.Services
{
    /// <summary>
    /// Log kayıtlarının dosya sistemine (.txt veya .csv formatlarında) aktarılmasını sağlayan I/O servisi.
    /// StreamWriter ve güvenli dosya akış yöntemlerini kullanır.
    /// </summary>
    public class FileExportService
    {
        private readonly StatisticsService _statisticsService = new StatisticsService();

        /// <summary>
        /// Kayıtları ayrıntılı bir rapor formatında .txt dosyasına yazar.
        /// </summary>
        public bool ExportToTxt(string filePath, IEnumerable<KeyLogEntry> logs)
        {
            try
            {
                var logList = new List<KeyLogEntry>(logs);
                var summary = _statisticsService.GetEventSummary(logList);
                var topKeys = _statisticsService.GetTopKeys(logList, 5);

                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("================================================================================");
                    writer.WriteLine("           YMH219 NESNE TABANLI PROGRAMLAMA - EĞİTSEL KEY EVENT LOGGER         ");
                    writer.WriteLine("================================================================================");
                    writer.WriteLine($"Rapor Tarihi     : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine($"Toplam Kayıt     : {logList.Count} adet olay");
                    writer.WriteLine($"KeyDown Sayısı   : {summary.totalDown}");
                    writer.WriteLine($"KeyUp Sayısı     : {summary.totalUp}");
                    writer.WriteLine($"KeyPress Sayısı  : {summary.totalPress}");
                    writer.WriteLine($"Farklı Tuş Sayısı: {summary.uniqueKeys}");
                    writer.WriteLine("--------------------------------------------------------------------------------");
                    writer.WriteLine("EN ÇOK KULLANILAN TUŞLAR:");
                    if (topKeys.Count == 0)
                    {
                        writer.WriteLine("  (Henüz tuş basımı kaydedilmedi)");
                    }
                    else
                    {
                        for (int i = 0; i < topKeys.Count; i++)
                        {
                            writer.WriteLine($"  {i + 1}. {topKeys[i]}");
                        }
                    }
                    writer.WriteLine("================================================================================");
                    writer.WriteLine("GÜVENLİK BİLGİLENDİRMESİ:");
                    writer.WriteLine("Bu kayıt yalnızca uygulama formu odaktayken eğitim amacıyla alınmıştır.");
                    writer.WriteLine("Global hook, arka plan dinleme veya ağ transferi kesinlikle içermez.");
                    writer.WriteLine("================================================================================");
                    writer.WriteLine();
                    writer.WriteLine("ZAMAN                  ID     TÜR      TUŞ ADI        KOD  DEĞİŞTİRİCİ");
                    writer.WriteLine("---------------------  -----  -------  -------------  ---  -----------");

                    foreach (var entry in logList)
                    {
                        writer.WriteLine($"{entry.Timestamp:yyyy-MM-dd HH:mm:ss.fff}  " +
                                         $"{entry.Id,5}  " +
                                         $"{entry.EventType,-7}  " +
                                         $"{entry.KeyName,-13}  " +
                                         $"{entry.KeyCode,3}  " +
                                         $"{entry.Modifiers}");
                    }

                    writer.WriteLine();
                    writer.WriteLine("--- Rapor Sonu ---");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Kayıtları Excel ve veri analiz araçlarıyla uyumlu .csv dosyasına aktarır.
        /// </summary>
        public bool ExportToCsv(string filePath, IEnumerable<KeyLogEntry> logs)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("Id,Timestamp,EventType,KeyName,KeyCode,Modifiers");
                    foreach (var entry in logs)
                    {
                        writer.WriteLine(entry.ToCsvRow());
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
