using CurrencyConverter.Services.DTOs;
using CurrencyConverter.Services.Implementation;
using CurrencyConverter.Services.Interfaces;
using CurrencyConverter.Services.Models;
using CurrencyConverter.Services.Tests.DTOs;
using CurrencyConverter.Services.Tests.Helpers;

namespace CurrencyConverter.Services.Tests.Implementation
{
    public class FrankfurterClientServiceTest
    {

        private IFrankfurterClientService _frankfurterClientService;

        [Fact]
        public async Task FrankfurterClientService_GetLatestExchangeRates_ValidResult()
        {
            //Arrange
            var mockHttpClientFactory = HttpClientHelper.GetMockHttpClientFactoryForExpectedHttpResponse(MockHttpResponse.GetLatestCurrencyRateMockResponse());
            _frankfurterClientService = new FrankfurterClientService(mockHttpClientFactory.Object);

            var fromCurrency = "EUR";
            var toCurrencies = "AUD,USD";

            //Act
            var results = await _frankfurterClientService.GetLatestExchangeRates(fromCurrency, toCurrencies);

            //Asert
            Assert.IsType<LatestCurrencyRate>(results);
            Assert.NotNull(results?.Rates);
        }

        [Fact]
        public async Task FrankfurterClientService_ConvertLatestExchangeRates_ValidResult()
        {
            //Arrange
            var mockHttpClientFactory = HttpClientHelper.GetMockHttpClientFactoryForExpectedHttpResponse(MockHttpResponse.GetLatestRatesConversionMockResponse());
            _frankfurterClientService = new FrankfurterClientService(mockHttpClientFactory.Object);

            LatestRateConversionRequestDTO latestRateConversionRequestDTO = new() { Amount = 10, From = "EUR", To = ["USD", "BGN", "MXN"] };

            //Act
            var results = await _frankfurterClientService.ConvertLatestExchangeRates(latestRateConversionRequestDTO);

            //Asert
            Assert.IsType<LatestCurrencyRate>(results);
            Assert.NotNull(results?.Rates);
        }

        [Fact]
        public async Task FrankfurterClientService_GetHistoricalExchangeRates_ValidResult()
        {
            //Arrange
            var mockHttpClientFactory = HttpClientHelper.GetMockHttpClientFactoryForExpectedHttpResponse(MockHttpResponse.GetHistoricalExchangeRateMockResponse());
            _frankfurterClientService = new FrankfurterClientService(mockHttpClientFactory.Object);

            HistoricalRatesRequestDTO historicalRatesRequestDTO = new() { StartDate = new DateTime(2024, 07, 08), EndDate = new DateTime(2024, 07, 09), BaseCurrency = "EUR" };

            //Act
            var results = await _frankfurterClientService.GetHistoricalExchangeRates(historicalRatesRequestDTO);

            //Asert
            Assert.IsType<HistoricalCurrencyRate>(results);
            Assert.NotNull(results?.Rates);
        }
    }
}
