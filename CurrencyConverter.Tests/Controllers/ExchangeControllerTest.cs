using AutoMapper;
using CurrencyConverter.Controllers;
using CurrencyConverter.Profiles;
using CurrencyConverter.Services.DTOs;
using CurrencyConverter.Services.Interfaces;
using CurrencyConverter.Services.Tests.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;

namespace CurrencyConverter.Tests.Controllers
{
    public class ExchangeControllerTest
    {
        private Mock<IFrankfurterClientService> _frankfurterClientService;
        private Mock<ILogger<ExchangeController>> _logger;
        private IMapper _mapper;

        public ExchangeControllerTest()
        {
            _frankfurterClientService = new Mock<IFrankfurterClientService>();
            _logger = new Mock<ILogger<ExchangeController>>();
            InitializeMockAutoMapper();
        }

        private void InitializeMockAutoMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public async Task ExchangeController_GetLatestRates_OK()
        {
            //Arrange
            var fromCurrency = "EUR";
            var toCurrencies = new List<string>() { "AUD", "USD" };
            _frankfurterClientService.Setup(x => x.GetLatestExchangeRates(fromCurrency, string.Join(",", toCurrencies))).ReturnsAsync(MockHttpResponse.GetLatestCurrencyRateMockResponse());

            ExchangeController exchangeController = new ExchangeController(_frankfurterClientService.Object, _mapper, _logger.Object);

            //Act
            var results = await exchangeController.GetLatestRates(fromCurrency, toCurrencies);
            var resultsObj = results as ObjectResult;

            //Assert
            Assert.Equal(200, resultsObj.StatusCode);
        }

        [Fact]
        public async Task ExchangeController_GetLatestRatesConversion_OK()
        {
            //Arrange
            LatestRateConversionRequestDTO latestRateConversionRequestDTO = new() { Amount = 10, From = "EUR", To = ["USD", "BGN"] };

            _frankfurterClientService.Setup(x => x.ConvertLatestExchangeRates(latestRateConversionRequestDTO)).ReturnsAsync(MockHttpResponse.GetLatestRatesConversionMockResponse());

            ExchangeController exchangeController = new ExchangeController(_frankfurterClientService.Object, _mapper, _logger.Object);

            //Act
            var results = await exchangeController.LatestRatesConversion(latestRateConversionRequestDTO);
            var resultsObj = results as ObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, resultsObj.StatusCode);
        }

        [Fact]
        public async Task ExchangeController_GetLatestRatesConversion_BadRequest()
        {
            //Arrange
            LatestRateConversionRequestDTO latestRateConversionRequestDTO = new() { Amount = 10, From = "EUR", To = ["USD", "BGN", "MXN"] };

            _frankfurterClientService.Setup(x => x.ConvertLatestExchangeRates(latestRateConversionRequestDTO)).ReturnsAsync(MockHttpResponse.GetLatestRatesConversionMockResponse());

            ExchangeController exchangeController = new ExchangeController(_frankfurterClientService.Object, _mapper, _logger.Object);

            //Act
            var results = await exchangeController.LatestRatesConversion(latestRateConversionRequestDTO);
            var resultsObj = results as ObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, resultsObj.StatusCode);
        }

        [Fact]
        public async Task ExchangeController_GetHistoricalRates_OK()
        {
            //Arrange
            HistoricalRatesRequestDTO historicalRatesRequestDTO = new() { StartDate = new DateTime(2024, 07, 08), EndDate = new DateTime(2024, 07, 09), BaseCurrency = "EUR", PageNumber = 1, PageSize = 1 };

            _frankfurterClientService.Setup(x => x.GetHistoricalExchangeRates(historicalRatesRequestDTO)).ReturnsAsync(MockHttpResponse.GetHistoricalExchangeRateMockHTTPResponse());

            ExchangeController exchangeController = new ExchangeController(_frankfurterClientService.Object, _mapper, _logger.Object);

            //Act
            var results = await exchangeController.GetHistoricalRates(historicalRatesRequestDTO);
            var resultsObj = results as ObjectResult;

            //Assert
            Assert.Equal(200, resultsObj.StatusCode);
        }


    }
}
