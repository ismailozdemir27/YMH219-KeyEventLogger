using System;
using System.Collections.Generic;
using System.Linq;
using KeyEventLogger.Enums;
using KeyEventLogger.Models;

namespace KeyEventLogger.Services
{
    /// <summary>
    /// Kaydedilen tuş olaylarının istatistiksel analizini ve frekans dağılımını hesaplayan servis.
    /// İsteğe bağlı geliştirme gereksinimlerini karşılar.
    /// </summary>
    public class StatisticsService
    {
        /// <summary>
        /// En sık kullanılan tuşların frekans listesini hesaplar.
        /// </summary>
        public List<KeyStatistic> GetTopKeys(IEnumerable<KeyLogEntry> logs, int limit = 5)
        {
            // İstatistiklerde tuş basımlarını (KeyDown veya KeyPress) esas al
            var pressLogs = logs.Where(l => l.EventType == KeyEventType.KeyDown).ToList();
            int totalPresses = pressLogs.Count;

            if (totalPresses == 0)
            {
                return new List<KeyStatistic>();
            }

            return pressLogs
                .GroupBy(l => l.KeyName)
                .OrderByDescending(g => g.Count())
                .Take(limit)
                .Select(g =>
                {
                    double pct = (double)g.Count() / totalPresses * 100.0;
                    return new KeyStatistic(g.Key, g.Count(), pct);
                })
                .ToList();
        }

        /// <summary>
        /// Olay türlerine göre toplam adetleri döner.
        /// </summary>
        public (int totalDown, int totalUp, int totalPress, int uniqueKeys) GetEventSummary(IEnumerable<KeyLogEntry> logs)
        {
            var logList = logs.ToList();
            int down = logList.Count(l => l.EventType == KeyEventType.KeyDown);
            int up = logList.Count(l => l.EventType == KeyEventType.KeyUp);
            int press = logList.Count(l => l.EventType == KeyEventType.KeyPress);
            int unique = logList.Select(l => l.KeyName).Distinct().Count();

            return (down, up, press, unique);
        }
    }
}
