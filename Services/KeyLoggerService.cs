using System;
using System.Collections.Generic;
using System.Linq;
using KeyEventLogger.Enums;
using KeyEventLogger.Models;

namespace KeyEventLogger.Services
{
    /// <summary>
    /// Klavye olaylarının kaydedilmesi, durum kontrolü ve filtrelenmesini yöneten servis.
    /// Nesne yönelimli mimaride iş mantığı (business logic) katmanını temsil eder.
    /// </summary>
    public class KeyLoggerService
    {
        private readonly List<KeyLogEntry> _logs = new List<KeyLogEntry>();
        private int _nextId = 1;

        public LoggingStatus Status { get; private set; } = LoggingStatus.Stopped;

        public event Action<KeyLogEntry>? OnKeyLogged;
        public event Action<LoggingStatus>? OnStatusChanged;
        public event Action? OnLogsCleared;

        public bool IsActive => Status == LoggingStatus.Active;
        public int TotalCount => _logs.Count;

        /// <summary>
        /// Kayıt işlemini başlatır.
        /// </summary>
        public void Start()
        {
            if (Status != LoggingStatus.Active)
            {
                Status = LoggingStatus.Active;
                OnStatusChanged?.Invoke(Status);
            }
        }

        /// <summary>
        /// Kayıt işlemini durdurur.
        /// </summary>
        public void Stop()
        {
            if (Status != LoggingStatus.Stopped)
            {
                Status = LoggingStatus.Stopped;
                OnStatusChanged?.Invoke(Status);
            }
        }

        /// <summary>
        /// Pencere içinde yakalanan klavye olayını kayda ekler.
        /// </summary>
        public KeyLogEntry? RecordEvent(KeyEventType eventType, string keyName, int keyCode, string modifiers)
        {
            if (Status != LoggingStatus.Active)
            {
                return null;
            }

            KeyLogEntry entry = new KeyLogEntry(_nextId++, eventType, keyName, keyCode, modifiers);
            _logs.Add(entry);

            OnKeyLogged?.Invoke(entry);
            return entry;
        }

        /// <summary>
        /// Tüm kayıtları temizler.
        /// </summary>
        public void Clear()
        {
            _logs.Clear();
            _nextId = 1;
            OnLogsCleared?.Invoke();
        }

        /// <summary>
        /// Mevcut tüm logların kopyasını döner.
        /// </summary>
        public List<KeyLogEntry> GetAllLogs()
        {
            return new List<KeyLogEntry>(_logs);
        }

        /// <summary>
        /// Kayıtları arama metni, olay türü ve tarih/saat aralığına göre filtreler.
        /// (İsteğe bağlı gereksinimleri karşılar)
        /// </summary>
        public List<KeyLogEntry> FilterLogs(string? keySearch, KeyEventType? eventTypeFilter, DateTime? startTime, DateTime? endTime)
        {
            IEnumerable<KeyLogEntry> query = _logs;

            if (!string.IsNullOrWhiteSpace(keySearch))
            {
                query = query.Where(l => l.KeyName.Contains(keySearch, StringComparison.OrdinalIgnoreCase) ||
                                         l.Modifiers.Contains(keySearch, StringComparison.OrdinalIgnoreCase));
            }

            if (eventTypeFilter.HasValue)
            {
                query = query.Where(l => l.EventType == eventTypeFilter.Value);
            }

            if (startTime.HasValue)
            {
                query = query.Where(l => l.Timestamp >= startTime.Value);
            }

            if (endTime.HasValue)
            {
                query = query.Where(l => l.Timestamp <= endTime.Value);
            }

            return query.ToList();
        }
    }
}
