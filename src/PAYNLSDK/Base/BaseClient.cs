using PAYNLSDK.Services;

namespace PAYNLSDK.Base
{
    public abstract class BaseClient
    {
        public IClientService ClientService { get; }

        protected BaseClient(IClientService clientService)
        {
            ClientService = clientService;
        }
    }
}
