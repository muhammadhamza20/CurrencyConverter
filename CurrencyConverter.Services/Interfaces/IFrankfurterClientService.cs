using CurrencyConverter.Services.DTOs;
using CurrencyConverter.Services.Models;

namespace CurrencyConverter.Services.Interfaces
{
    public interface IFrankfurterClientService
    {
        Task<LatestCurrencyRate> GetLatestExchangeRates(string fromCurrency, string toCurrencies = null);
        Task<LatestCurrencyRate> ConvertLatestExchangeRates(LatestRateConversionRequestDTO requestDTO);
        Task<HistoricalCurrencyRate> GetHistoricalExchangeRates(HistoricalRatesRequestDTO requestDTO);
    }
}
