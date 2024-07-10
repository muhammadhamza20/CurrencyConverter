namespace CurrencyConverter.Services.Models
{
    public class LatestCurrencyRate : CurrencyRate
    {
        public DateTime Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
