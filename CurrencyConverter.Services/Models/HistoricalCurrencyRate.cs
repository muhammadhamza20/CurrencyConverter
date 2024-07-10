namespace CurrencyConverter.Services.Models
{
    public class HistoricalCurrencyRate : CurrencyRate
    {
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public Dictionary<DateTime, Dictionary<string, decimal>> Rates { get; set; }
    }
}
