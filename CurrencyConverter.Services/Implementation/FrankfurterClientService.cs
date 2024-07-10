using CurrencyConverter.Services.DTOs;
using CurrencyConverter.Services.Helpers;
using CurrencyConverter.Services.Interfaces;
using CurrencyConverter.Services.Models;
using System.Net.Http.Json;
using System.Text;

namespace CurrencyConverter.Services.Implementation
{
    public class FrankfurterClientService : IFrankfurterClientService
    {
        public const string ClientName = "Frankfurter";
        private readonly IHttpClientFactory _httpClientFactory;

        public FrankfurterClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<LatestCurrencyRate> GetLatestExchangeRates(string fromCurrency, string toCurrencies = null)
        {
            StringBuilder uri = new();
            uri.Append("latest?from=").Append(fromCurrency);

            if (!string.IsNullOrWhiteSpace(toCurrencies))
                uri.Append("&to=").Append(toCurrencies);

            HttpClient client = _httpClientFactory.CreateClient(ClientName);
            HttpResponseMessage response = await client.GetAsync(uri.ToString());
            return await response.Content.ReadFromJsonAsync<LatestCurrencyRate>();
        }

        public async Task<LatestCurrencyRate> ConvertLatestExchangeRates(LatestRateConversionRequestDTO requestDTO)
        {
            StringBuilder uri = new();
            uri.Append("latest?amount=").Append(requestDTO.Amount).Append("&from=").Append(requestDTO.From).Append("&to=").Append(string.Join(",", requestDTO.To.Except(ApplicationConstants.DeniedConversionCurrencyCodes)));

            HttpClient client = _httpClientFactory.CreateClient(ClientName);
            HttpResponseMessage response = await client.GetAsync(uri.ToString());
            return await response.Content.ReadFromJsonAsync<LatestCurrencyRate>();
        }

        public async Task<HistoricalCurrencyRate> GetHistoricalExchangeRates(HistoricalRatesRequestDTO requestDTO)
        {
            StringBuilder uri = new();
            uri.Append(requestDTO.StartDate.ToString("yyyy-MM-dd")).Append("..");

            if (requestDTO.EndDate > DateTime.MinValue)
                uri.Append(requestDTO.EndDate.ToString("yyyy-MM-dd"));

            uri.Append("?from=").Append(requestDTO.BaseCurrency);

            HttpClient client = _httpClientFactory.CreateClient(ClientName);
            HttpResponseMessage response = await client.GetAsync(uri.ToString());
            return await response.Content.ReadFromJsonAsync<HistoricalCurrencyRate>();
        }
    }
}
