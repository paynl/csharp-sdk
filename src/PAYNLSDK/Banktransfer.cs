using PAYNLSDK.Base;
using PAYNLSDK.Services;
using System.Threading.Tasks;

namespace PAYNLSDK
{
    public class Banktransfer : BaseClient
    {
        public Banktransfer(IClientService clientService)
            : base(clientService)
        {
        }

        public async Task<API.Banktransfer.Add.Response> AddAsync(API.Banktransfer.Add.Request request)
        {
            await ClientService.PerformRequestAsync(request);
            return request.Response;
        }

        public async Task<API.Banktransfer.Add.Response> AddAsync(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            var request = new API.Banktransfer.Add.Request(amount, bankAccountHolder, bankAccountNumber, bankAccountBic);
            await ClientService.PerformRequestAsync(request);
            return request.Response;
        }
    }
}
