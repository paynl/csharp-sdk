using PAYNLSDK.API;
using PAYNLSDK.Net.ProxyConfigurationInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.Net
{
    public interface IClient
    {
        /// <summary>
        /// PAYNL API TOKEN
        /// </summary>
        string ApiToken { get; }
        /// <summary>
        /// PAYNL SERVICE ID
        /// </summary>
        string ServiceID { get; }

        /// <summary>
        /// Proxy injector
        /// </summary>
        IProxyConfigurationInjector ProxyConfigurationInjector { get; }

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
        string PerformRequest(RequestBase request);
    }
}
