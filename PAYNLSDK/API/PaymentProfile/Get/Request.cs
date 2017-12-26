using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.PaymentProfile.Get
{
    public class Request : RequestBase
    {
        [JsonProperty("paymentProfileId")]
        public int PaymentProfileId { get; set; }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "PaymentProfile"; }
        }

        public override string Method
        {
            get { return "get"; }
        }
        
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotNull(PaymentProfileId, "PaymentProfileId");
            nvc.Add("paymentProfileId", PaymentProfileId.ToString());

            return nvc;
        }

        public Response Response { get { return (Response)response; } }


        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            PAYNLSDK.Objects.PaymentProfile pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.PaymentProfile>(RawResponse);
            Response r = new Response();
            r.PaymentProfile = pm;
            response = r;
        }
    }
}
