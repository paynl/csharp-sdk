using System;
using System.Net;
using System.Threading.Tasks;
using PAYNLSDK.API;
using System.Net.Http;

namespace PAYNLSDK.Net
{
    public class Client : IClient
    {
        /// <summary>
        /// PAYNL API TOKEN
        /// </summary>
        public string ApiToken
        {
            get;
        }

        /// <summary>
        /// PAYNL SERVICE ID
        /// </summary>
        public string ServiceID
        {
            get;
        }

        /// <summary>
        /// Proxy injector
        /// </summary>
        public IWebProxy ProxyConfiguration { get; }

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
            get { return string.Format("PAYNL/SDK/{0} DotNet/{1}", ClientVersion, ""); }
        }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        /// <param name="serviceID">PAYNL Service ID</param>
        /// <param name="proxyConfigurationInjector">Proxy Injector</param>
        public Client(string apiToken, string serviceID, IWebProxy proxyConfiguration)
        {
            ApiToken = apiToken;
            ServiceID = serviceID;
            ProxyConfiguration = proxyConfiguration;
        }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        /// <param name="serviceID">PAYNL Service ID</param>
        public Client(string apiToken, string serviceID)
            : this(apiToken, serviceID, null)
        {
        }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        public Client(string apiToken)
            : this(apiToken, null, null)
        {
        }

        /// <summary>
        /// create new Client
        /// </summary>
        public Client()
            : this(null, null, null)
        {
        }

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        public async Task<string> PerformRequestAsync(RequestBase request)
        {
            string result;

            using (var httpClient = PrepareHttpClient(request.Url))
            {
                using (var response = await httpClient.PostAsync(request.Url, new StringContent(request.Querystring)))
                {
                    response.EnsureSuccessStatusCode();
                    result = await response.Content.ReadAsStringAsync();
                    request.RawResponse = result;
                }
            }

            return result;
        }

        /// <summary>
        /// Prepares a request
        /// </summary>
        /// <param name="requestUriString">URL to call</param>
        /// <param name="method">Request Method (get, post, delete, put)</param>
        /// <returns></returns>
        private HttpClient PrepareHttpClient(string requestUriString)
        {
            var uriString = string.Format("{0}/{1}", Constants.Endpoint, requestUriString);
            var uri = new Uri(uriString);

            var httpClientHandler = new HttpClientHandler();

            if (ProxyConfiguration != null)
            {
                httpClientHandler.Proxy = ProxyConfiguration;
            }

            var httpClient = new HttpClient(httpClientHandler, true)
            {
                BaseAddress = uri
            };

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
            httpClient.DefaultRequestHeaders.Accept.ParseAdd(Constants.ApplicationJsonContentType);
            httpClient.DefaultRequestHeaders.AcceptEncoding.ParseAdd(Constants.WWWUrlContentType);

            return httpClient;
        }
    }
}
