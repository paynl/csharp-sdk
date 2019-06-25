using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.Service.GetCategories
{
    public class Request : RequestBase
    {
        [JsonProperty("paymentOptionId")]
        public int? PaymentOptionId { get; set; }

        public override int Version
        {
            get { return 3; }
        }

        public override string Controller
        {
            get { return "Service"; }
        }

        public override string Method
        {
            get { return "getCategories"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters()
        {
            var nvc = base.GetParameters();
            if (!ParameterValidator.IsNonEmptyInt(PaymentOptionId))
            {
                nvc.Add("paymentOptionId", PaymentOptionId.ToString());
            }
            return nvc;
        }

        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            var pm = JsonConvert.DeserializeObject<Objects.ServiceCategory[]>(RawResponse);
            var r = new Response
            {
                ServiceCategories = pm
            };
            response = r;
        }
    }
}
