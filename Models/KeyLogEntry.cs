using System;
using KeyEventLogger.Enums;

namespace KeyEventLogger.Models
{
    /// <summary>
    /// Pencere içinde gerçekleşen tek bir klavye olayını temsil eden model sınıfı.
    /// Nesne tabanlı tasarım kurallarına uygun olarak veri kapsülleme (encapsulation) uygular.
    /// </summary>
    public class KeyLogEntry
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public KeyEventType EventType { get; set; }
        public string KeyName { get; set; }
        public int KeyCode { get; set; }
        public string Modifiers { get; set; }

        public KeyLogEntry(int id, KeyEventType eventType, string keyName, int keyCode, string modifiers)
        {
            Id = id;
            Timestamp = DateTime.Now;
            EventType = eventType;
            KeyName = keyName;
            KeyCode = keyCode;
            Modifiers = string.IsNullOrWhiteSpace(modifiers) ? "Yok" : modifiers;
        }

        /// <summary>
        /// Olayın okunabilir konsol / metin satırı karşılığı.
        /// </summary>
        public string ToFormattedString()
        {
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [ID: {Id:D4}] " +
                   $"Tür: {EventType,-8} | Tuş: {KeyName,-12} | Kod: {KeyCode,3} | Değiştirici: {Modifiers}";
        }

        /// <summary>
        /// CSV formatında dışa aktarma satırı.
        /// </summary>
        public string ToCsvRow()
        {
            return $"{Id},{Timestamp:yyyy-MM-dd HH:mm:ss.fff},{EventType},{EscapeCsv(KeyName)},{KeyCode},{EscapeCsv(Modifiers)}";
        }

        private static string EscapeCsv(string value)
        {
            if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
        }
    }
}
