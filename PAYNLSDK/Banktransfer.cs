using PAYNLSDK.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK
{
    /// <summary>
    /// the Bank Transfer API
    /// </summary>
    public class Banktransfer
    {
        private readonly IClient _webClient;

        /// <summary>
        /// Create a new BankTransfer api object
        /// </summary>
        /// <param name="webClient"></param>
        public Banktransfer(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public API.Banktransfer.Add.Response Add(PAYNLSDK.API.Banktransfer.Add.Request request)
        {
            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="bankAccountHolder"></param>
        /// <param name="bankAccountNumber"></param>
        /// <param name="bankAccountBic"></param>
        /// <returns></returns>
        public API.Banktransfer.Add.Response Add(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            var request = new API.Banktransfer.Add.Request(amount, bankAccountHolder, bankAccountNumber, bankAccountBic);
            _webClient.PerformRequest(request);
            return request.Response;
        }
    }
}
