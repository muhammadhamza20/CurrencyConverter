using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace CurrencyConverter.Services.DTOs
{
    public class HistoricalRatesRequestDTO
    {
        [BindRequired]

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string BaseCurrency { get; set; } = "EUR";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
