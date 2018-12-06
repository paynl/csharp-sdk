using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.PaymentProfile.Get
{
    public class Request : RequestBase
    {
        
        [JsonProperty("paymentProfileId")]
        public int PaymentProfileId { get; set; }

        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "PaymentProfile";

        /// <inheritdoc />
        protected override string Method => "get";

        /// <inheritdoc />
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotNull(PaymentProfileId, "PaymentProfileId");
            nvc.Add("paymentProfileId", PaymentProfileId.ToString());

            return nvc;
        }

        public Response Response => (Response)response;


        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            PAYNLSDK.Objects.PaymentProfile pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.PaymentProfile>(RawResponse);
            Response r = new Response
            {
                PaymentProfile = pm
            };
            response = r;
        }
    }
}
