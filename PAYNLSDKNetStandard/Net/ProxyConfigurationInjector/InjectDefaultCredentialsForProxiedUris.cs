using System.Net;

namespace PAYNLSDK.Net.ProxyConfigurationInjector
{
    public class InjectDefaultCredentialsForProxiedUris: InjectCredentialsForProxiedUris 
    {
        public InjectDefaultCredentialsForProxiedUris(): base (CredentialCache.DefaultCredentials)
        {
        }
    }
}
