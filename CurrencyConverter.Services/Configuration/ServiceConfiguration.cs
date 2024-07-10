using CurrencyConverter.Services.Implementation;
using CurrencyConverter.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using System.Net.Http.Headers;

namespace CurrencyConverter.Services.Configuration
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFrankfurterClientService, FrankfurterClientService>();
            services.AddHttpClient(FrankfurterClientService.ClientName, httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.frankfurter.app/");

                httpClient.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            })
            .AddTransientHttpErrorPolicy(x =>
                x.WaitAndRetryAsync(
                    Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5))); //Policy for forcing retry attempts.
        }
    }
}
