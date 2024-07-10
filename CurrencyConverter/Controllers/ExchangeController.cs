using AutoMapper;
using CurrencyConverter.Services.DTOs;
using CurrencyConverter.Services.Helpers;
using CurrencyConverter.Services.Interfaces;
using CurrencyConverter.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private IFrankfurterClientService _frankfurterClientService;
        private readonly ILogger<ExchangeController> _logger;
        private readonly IMapper _mapper;

        public ExchangeController(IFrankfurterClientService frankfurterClientService, IMapper mapper, ILogger<ExchangeController> logger)
        {
            _frankfurterClientService = frankfurterClientService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestRates([FromQuery] string? from = "EUR", [FromQuery] List<string>? to = null)
        {
            try
            {
                LatestCurrencyRate rates = to != null
                    ? await _frankfurterClientService.GetLatestExchangeRates(from, string.Join(",", to))
                    : await _frankfurterClientService.GetLatestExchangeRates(from);

                return rates is not null ? Ok(rates) : BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpGet("latest-rate-conversion")]
        public async Task<IActionResult> LatestRatesConversion([FromQuery] LatestRateConversionRequestDTO requestDTO)
        {
            try
            {
                LatestCurrencyRate rates = await _frankfurterClientService.ConvertLatestExchangeRates(requestDTO);
                return rates is not null ? !requestDTO.To.Intersect(ApplicationConstants.DeniedConversionCurrencyCodes).Any() ? Ok(rates) : BadRequest(rates) : BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpGet("historical")]
        public async Task<IActionResult> GetHistoricalRates([FromQuery] HistoricalRatesRequestDTO requestDTO)
        {
            try
            {
                HistoricalRatesResponseDTO historicalRatesResponse = new();
                HistoricalCurrencyRate historicalCurrencyRates = await _frankfurterClientService.GetHistoricalExchangeRates(requestDTO);

                if (historicalCurrencyRates?.Rates is not null)
                {
                    historicalRatesResponse = _mapper.Map<HistoricalRatesResponseDTO>(historicalCurrencyRates);
                    historicalRatesResponse.Rates = new()
                    {
                        PageNumber = requestDTO.PageNumber,
                        PageSize = requestDTO.PageSize,
                        TotalRecords = historicalCurrencyRates.Rates != null ? historicalCurrencyRates.Rates.Count : 0,
                        TotalPages = historicalCurrencyRates.Rates != null ? (int)Math.Ceiling(historicalCurrencyRates.Rates.Count / (decimal)requestDTO.PageSize) : 0,
                        Rates = historicalCurrencyRates.Rates != null ? historicalCurrencyRates.Rates.Skip((requestDTO.PageNumber - 1) * requestDTO.PageSize).Take(requestDTO.PageSize).ToDictionary() : default
                    };
                }
                else
                    historicalRatesResponse = _mapper.Map<HistoricalRatesResponseDTO>(requestDTO);

                return historicalRatesResponse is not null ? Ok(historicalRatesResponse) : BadRequest();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex);
            }
        }
    }
}
