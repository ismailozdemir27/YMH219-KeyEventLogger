namespace KeyEventLogger.Models
{
    /// <summary>
    /// Tuş kullanım frekansı ve yüzdelik dağılımını temsil eden istatistik modeli.
    /// </summary>
    public class KeyStatistic
    {
        public string KeyName { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Percentage { get; set; }

        public KeyStatistic(string keyName, int count, double percentage)
        {
            KeyName = keyName;
            Count = count;
            Percentage = percentage;
        }

        public override string ToString()
        {
            return $"{KeyName,-12} : {Count,4} kez (%{Percentage:F1})";
        }
    }
}
