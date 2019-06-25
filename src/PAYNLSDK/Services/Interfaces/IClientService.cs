using System.Net;
using System.Threading.Tasks;
using PAYNLSDK.API;

namespace PAYNLSDK.Services
{
    public interface IClientService
    {
        ISettingsService Settings { get; }

        /// <summary>
        /// Proxy injector
        /// </summary>
        IWebProxy ProxyConfiguration { get; }

        /// <summary>
        /// API VERSION
        /// </summary>
        string ApiVersion { get; }

        /// <summary>
        /// Client version
        /// </summary>
        string ClientVersion { get; }

        /// <summary>
        /// User agent
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        Task<string> PerformRequestAsync(RequestBase request);
    }
}
