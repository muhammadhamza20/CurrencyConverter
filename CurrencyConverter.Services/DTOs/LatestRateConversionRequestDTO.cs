using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Services.DTOs
{
    public class LatestRateConversionRequestDTO
    {
        [BindRequired, Range(0, double.MaxValue, ErrorMessage = "Invalid Amount")]
        public decimal Amount { get; set; }

        [BindRequired, DeniedValues("TRY", "PLN", "THB", "MXN")]
        public string From { get; set; }

        [BindRequired]
        public List<string> To { get; set; }
    }
}
