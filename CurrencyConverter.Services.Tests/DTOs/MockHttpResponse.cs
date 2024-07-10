using CurrencyConverter.Services.DTOs;
using CurrencyConverter.Services.Models;

namespace CurrencyConverter.Services.Tests.DTOs
{
    public class MockHttpResponse
    {
        public static LatestCurrencyRate GetLatestCurrencyRateMockResponse()
        {
            return new LatestCurrencyRate()
            {
                Amount = 1,
                Base = "EUR",
                Date = DateTime.Now.AddDays(-1),
                Rates = new Dictionary<string, decimal>
                {
                    { "AUD", (decimal)1.6062 },
                    { "USD", (decimal)1.0814 }
                }
            };
        }

        public static LatestCurrencyRate GetLatestRatesConversionMockResponse()
        {
            return new LatestCurrencyRate()
            {
                Amount = 10,
                Base = "EUR",
                Date = DateTime.Now.AddDays(-1),
                Rates = new Dictionary<string, decimal>
                {
                    { "BGN", (decimal)19.558 },
                    { "USD", (decimal)10.814 }
                }
            };
        }

        public static HistoricalCurrencyRate GetHistoricalExchangeRateMockResponse()
        {
            return new HistoricalCurrencyRate()
            {
                Amount = 1,
                Base = "EUR",
                Start_Date = new DateTime(2024, 07, 08),
                End_Date = new DateTime(2024, 07, 09),
                Rates = new Dictionary<DateTime, Dictionary<string, decimal>>()
                {
                    { 
                        DateTime.Parse("2024-07-08"), new Dictionary<string, decimal>()
                        {
                            { "AUD", (decimal)1.6067 },
                            { "BGN", (decimal)1.9558 },
                            { "BRL", (decimal)5.9265 },
                            { "CAD", (decimal)1.4772 },
                            { "CHF", (decimal)0.9711 },
                            { "CNY", (decimal)7.8766 },
                            { "CZK", (decimal)25.162 },
                            { "DKK", (decimal)7.4586 },
                            { "GBP", (decimal)0.8441 },
                            { "HKD", (decimal)8.4631 },
                            { "HUF", (decimal)394.7  },
                            { "IDR", (decimal)17624  },
                            { "ILS", (decimal)4.0023 },
                            { "INR", (decimal)90.47  },
                            { "ISK", (decimal)149.3  },
                            { "JPY", (decimal)174.37 },
                            { "KRW", (decimal)1499.05},
                            { "MXN", (decimal)19.5399},
                            { "MYR", (decimal)5.1022 },
                            { "NOK", (decimal)11.4575},
                            { "NZD", (decimal)1.7655 },
                            { "PHP", (decimal)63.462 },
                            { "PLN", (decimal)4.2778 },
                            { "RON", (decimal)4.9748 },
                            { "SEK", (decimal)11.3805},
                            { "SGD", (decimal)1.4618 },
                            { "THB", (decimal)39.461 },
                            { "TRY", (decimal)35.464 },
                            { "USD", (decimal)1.0835 },
                            { "ZAR", (decimal)19.6622}
                        }
                    },
                    {
                        DateTime.Parse("2024-07-09"), new Dictionary<string, decimal>()
                        {
                            { "AUD", (decimal)1.6062 },
                            { "BGN", (decimal)1.9558 },
                            { "BRL", (decimal)5.9075 },
                            { "CAD", (decimal)1.4752 },
                            { "CHF", (decimal)0.9712 },
                            { "CNY", (decimal)7.8639 },
                            { "CZK", (decimal)25.231 },
                            { "DKK", (decimal)7.4595 },
                            { "GBP", (decimal)0.84491},
                            { "HKD", (decimal)8.4477 },
                            { "HUF", (decimal)395.2  },
                            { "IDR", (decimal)17593  },
                            { "ILS", (decimal)3.9723 },
                            { "INR", (decimal)90.29  },
                            { "ISK", (decimal)149.1  },
                            { "JPY", (decimal)174.2  },
                            { "KRW", (decimal)1496.01},
                            { "MXN", (decimal)19.4858},
                            { "MYR", (decimal)5.0907 },
                            { "NOK", (decimal)11.489 },
                            { "NZD", (decimal)1.7681 },
                            { "PHP", (decimal)63.209 },
                            { "PLN", (decimal)4.2643 },
                            { "RON", (decimal)4.9731 },
                            { "SEK", (decimal)11.422 },
                            { "SGD", (decimal)1.4608 },
                            { "THB", (decimal)39.379 },
                            { "TRY", (decimal)35.598 },
                            { "USD", (decimal)1.0814 },
                            { "ZAR", (decimal)19.654 }
                        }
                    }
                }
            };
        }

        public static HistoricalCurrencyRate GetHistoricalExchangeRateMockHTTPResponse()
        {
            return new HistoricalCurrencyRate()
            {
                Amount = 1,
                Base = "EUR",
                Start_Date = new DateTime(2024, 07, 08),
                End_Date = new DateTime(2024, 07, 09),
                Rates = new Dictionary<DateTime, Dictionary<string, decimal>>()
                {
                    {
                        DateTime.Parse("2024-07-08"), new Dictionary<string, decimal>()
                        {
                            { "AUD", (decimal)1.6067 },
                            { "BGN", (decimal)1.9558 },
                            { "BRL", (decimal)5.9265 },
                            { "CAD", (decimal)1.4772 },
                            { "CHF", (decimal)0.9711 },
                            { "CNY", (decimal)7.8766 },
                            { "CZK", (decimal)25.162 },
                            { "DKK", (decimal)7.4586 },
                            { "GBP", (decimal)0.8441 },
                            { "HKD", (decimal)8.4631 },
                            { "HUF", (decimal)394.7  },
                            { "IDR", (decimal)17624  },
                            { "ILS", (decimal)4.0023 },
                            { "INR", (decimal)90.47  },
                            { "ISK", (decimal)149.3  },
                            { "JPY", (decimal)174.37 },
                            { "KRW", (decimal)1499.05},
                            { "MXN", (decimal)19.5399},
                            { "MYR", (decimal)5.1022 },
                            { "NOK", (decimal)11.4575},
                            { "NZD", (decimal)1.7655 },
                            { "PHP", (decimal)63.462 },
                            { "PLN", (decimal)4.2778 },
                            { "RON", (decimal)4.9748 },
                            { "SEK", (decimal)11.3805},
                            { "SGD", (decimal)1.4618 },
                            { "THB", (decimal)39.461 },
                            { "TRY", (decimal)35.464 },
                            { "USD", (decimal)1.0835 },
                            { "ZAR", (decimal)19.6622}
                        }
                    }
                }
            };
        }

    }
}
