using PAYNLSDK.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK
{
    public class Banktransfer
    {
        private readonly IClient _webClient;
     
        public Banktransfer(IClient webClient)
        {
            _webClient = webClient;
        }

        public API.Banktransfer.Add.Response Add(PAYNLSDK.API.Banktransfer.Add.Request request)
        {
            _webClient.PerformRequest(request);
            return request.Response;
        }

        public API.Banktransfer.Add.Response Add(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            var request = new API.Banktransfer.Add.Request(amount, bankAccountHolder, bankAccountNumber, bankAccountBic);
            _webClient.PerformRequest(request);
            return request.Response;
        }
    }
}
