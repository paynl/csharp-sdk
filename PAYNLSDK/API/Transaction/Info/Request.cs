using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.Info
{
    public class Request : RequestBase
    {

        public string TransactionId { get; set; }

        public string EntranceCode { get; set; }

        public override int Version
        {
            get { return 5; }
        }

        public override string Controller
        {
            get { return "Transaction"; }
        }

        public override string Method
        {
            get { return "info"; }
        }
        
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();
            
            ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
            nvc.Add("transactionId", TransactionId);

            if (!ParameterValidator.IsEmpty(EntranceCode))
            {
                nvc.Add("entranceCode", EntranceCode);
            }
            return nvc;
        }
        public Response Response { get { return (Response)response; } }

        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    
    }
}
