using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PAYNLFormsApp.Objects;
using PAYNLSDK.API;

namespace PAYNLSDK.Services
{
    public class ClientService : IClientService
    {
        public AppSettings Settings { get; }

        /// <summary>
        /// API VERSION
        /// </summary>
        public string ApiVersion
        {
            get;
        }

        /// <summary>
        /// HttpClient Factory
        /// </summary>
        private IHttpClientFactory HttpClientFactory { get; }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        /// <param name="serviceID">PAYNL Service ID</param>
        /// <param name="proxyConfigurationInjector">Proxy Injector</param>
        public ClientService(IOptions<AppSettings> settings, IHttpClientFactory httpClientFactory)
        {
            Settings = settings.Value;
            HttpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        public async Task<string> PerformPostRequestAsync(RequestBase request)
        {
            var result = string.Empty;

            request.ApiToken = Settings.ApiToken;
            request.ServiceId = Settings.ServiceId;

            HttpClient httpClient;

            if (Settings.UseProxy)
            {
                httpClient = HttpClientFactory.CreateClient(Constants.HttpClientProxy);
            }
            else
            {
                httpClient = HttpClientFactory.CreateClient(Constants.HttpClientDefault);
            }

            if(httpClient != null)
            {
                using (var response = await httpClient.PostAsync(request.Url, new StringContent(request.ToQueryString(), Encoding.UTF8, Constants.WWWUrlContentType)))
                {
                    response.EnsureSuccessStatusCode();
                    result = await response.Content.ReadAsStringAsync();
                    request.RawResponse = result;
                }
            }

            return result;
        }
    }
}
