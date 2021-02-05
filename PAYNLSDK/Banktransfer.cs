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
        static public API.Banktransfer.Add.Response Add(PAYNLSDK.API.Banktransfer.Add.Request request)
        {
            Client c = new Client("", "");
            c.PerformRequest(request);
            return request.Response;
        }

        static public API.Banktransfer.Add.Response Add(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            Client c = new Client("", "");
            var request = new API.Banktransfer.Add.Request(amount, bankAccountHolder, bankAccountNumber, bankAccountBic);
            c.PerformRequest(request);
            return request.Response;
        }
    }
}
