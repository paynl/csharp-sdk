using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.GetService
{
    public class Request : RequestBase
    {
        public override bool RequiresServiceId
        {
            get
            {
                return true;
            }
        }

        [JsonProperty("paymentMethodId")]
        public PAYNLSDK.Enums.PaymentMethodId? PaymentMethodId { get; set; }

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
            get { return "getService"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();
            if (!ParameterValidator.IsNull(PaymentMethodId))
            {
                nvc.Add("paymentMethodId", ((int)PaymentMethodId).ToString());
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
