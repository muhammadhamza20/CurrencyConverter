using CurrencyConverter.Services.Tests.DTOs;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CurrencyConverter.Services.Tests.Helpers
{
    public class HttpClientHelper
    {
        public static Mock<IHttpClientFactory> GetMockHttpClientFactoryForExpectedHttpResponse<T>(T expectedResponse)
        {
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            var _httpMessageHandler = GetResults(expectedResponse);
            var httpClient = new HttpClient(_httpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.frankfurter.app/")
            };

            httpClient.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/json"));

            mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);
            return mockHttpClientFactory;
        }

        private static Mock<HttpMessageHandler> GetResults<T>(T expectedResponse)
        {
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
            };

            httpResponse.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                ).ReturnsAsync(httpResponse);

            return mockHandler;
        }
    }
}
