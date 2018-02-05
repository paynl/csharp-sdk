using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.PaymentMethod.Get
{
    public class Request : RequestBase
    {
        [JsonProperty("paymentMethodId")]
        public int PaymentMethodId { get; set; }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "PaymentMethod"; }
        }

        public override string Method
        {
            get { return "get"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = base.GetParameters();

            ParameterValidator.IsNotNull(PaymentMethodId, "PaymentMethodId");
            nvc.Add("paymentMethodId", PaymentMethodId.ToString());

            return nvc;
        }

        public Response Response { get { return (Response)response; } }


        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            PAYNLSDK.Objects.PaymentMethod pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.PaymentMethod>(RawResponse);
            Response r = new Response();
            r.PaymentMethod = pm;
            response = r;
        }
    }
}
