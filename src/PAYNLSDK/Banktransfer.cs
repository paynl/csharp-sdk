using PAYNLSDK.Net;
using System.Threading.Tasks;

namespace PAYNLSDK
{
    public class Banktransfer : Client
    {
        public Banktransfer(string apiToken, string serviceID)
            : base(apiToken, serviceID)
        {
        }

        public async Task<API.Banktransfer.Add.Response> AddAsync(API.Banktransfer.Add.Request request)
        {
            await PerformRequestAsync(request);
            return request.Response;
        }

        public async Task<API.Banktransfer.Add.Response> AddAsync(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            var request = new API.Banktransfer.Add.Request(amount, bankAccountHolder, bankAccountNumber, bankAccountBic);
            await PerformRequestAsync(request);
            return request.Response;
        }
    }
}
