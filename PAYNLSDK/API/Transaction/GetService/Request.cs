using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.GetService
{
    public class Request : RequestBase
    {
        public override bool RequiresServiceId => true;

        [JsonProperty("paymentMethodId")]
        public PAYNLSDK.Enums.PaymentMethodId? PaymentMethodId { get; set; }

        /// <inheritdoc />
        protected override int Version => 5;

        /// <inheritdoc />
        protected override string Controller => "Transaction";

        /// <inheritdoc />
        protected override string Method => "getService";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();
            if (!ParameterValidator.IsNull(PaymentMethodId))
            {
                nvc.Add("paymentMethodId", ((int)PaymentMethodId).ToString());
            }
            return nvc;
        }

        public Response Response => (Response)response;

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}
