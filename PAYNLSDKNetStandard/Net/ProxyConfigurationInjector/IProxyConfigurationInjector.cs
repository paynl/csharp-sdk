using System;
using System.Net;

namespace PAYNLSDK.Net.ProxyConfigurationInjector
{
    public interface IProxyConfigurationInjector
    {
        IWebProxy InjectProxyConfiguration(IWebProxy webProxy, Uri uri);
    }
}