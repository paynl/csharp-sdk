using PAYNLSDK.Net.ProxyConfigurationInjector;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.Net
{
    /// <inheritdoc />
    /// <summary>
    /// A client which can be constructed with an apiToken and a serviceid
    /// </summary>
    /// <seealso cref="T:PAYNLSDK.Net.Client" />
    public class ApiTokenClient : Client
    {
        /// <inheritdoc />
        public ApiTokenClient(string apiToken, string serviceId, IProxyConfigurationInjector proxyConfigurationInjector = null)
            : base(new PayNlConfiguration(apiToken, serviceId), proxyConfigurationInjector)
        {
        }

        public ApiTokenClient(IPayNlConfiguration securityConfiguration, IProxyConfigurationInjector proxyConfigurationInjector = null) : base(securityConfiguration, proxyConfigurationInjector)
        {
        }
    }
}
