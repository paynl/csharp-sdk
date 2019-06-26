using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PAYNLSDK.API;

namespace PAYNLSDK.Services
{
    public class ClientService : IClientService
    {
        public ISettingsService Settings { get; }

        /// <summary>
        /// API VERSION
        /// </summary>
        public string ApiVersion
        {
            get;
        }

        /// <summary>
        /// Client version
        /// </summary>
        public string ClientVersion
        {
            get { return "1.0.0.0"; }
        }

        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent
        {
            get { return $"PAYNL/SDK/{ClientVersion} DotNet/"; }
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
        public ClientService(ISettingsService settings, IHttpClientFactory httpClientFactory)
        {
            Settings = settings;
            HttpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        public async Task<string> PerformRequestAsync(RequestBase request)
        {
            string result;

            request.ApiToken = Settings.ApiToken;
            request.ServiceId = Settings.ServiceId;

            var httpClient = HttpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(Constants.Endpoint);

            // Use TryAddWithoutValidation because useragent format is not compatible
            httpClient.DefaultRequestHeaders
                .TryAddWithoutValidation(Constants.UserAgentHeader, UserAgent);

            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue(Constants.ApplicationJsonContentType));

            using (var response = await httpClient.PostAsync(request.Url, new StringContent(request.ToQueryString(), Encoding.UTF8, Constants.WWWUrlContentType)))
            {
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
                request.RawResponse = result;
            }

            return result;
        }
    }
}
