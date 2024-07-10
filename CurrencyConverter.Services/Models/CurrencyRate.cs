namespace CurrencyConverter.Services.Models
{
    public abstract class CurrencyRate
    {
        public decimal Amount { get; set; }

        public string Base { get; set; }
    }
}
