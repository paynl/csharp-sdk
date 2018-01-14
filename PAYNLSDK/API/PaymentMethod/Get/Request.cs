using System.Collections.Specialized;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.PaymentMethod.Get
{
    /// <summary>
    /// The model to request a particular paymentMethod
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// The paymentMethod to be used
        /// </summary>
        [JsonProperty("paymentMethodId")]
        public Enums.PaymentMethodId PaymentMethodId { get; set; }

        /// <inheritdoc />
        public override int Version
        {
            get { return 1; }
        }

        /// <inheritdoc />
        public override string Controller
        {
            get { return "PaymentMethod"; }
        }

        /// <inheritdoc />
        public override string Method
        {
            get { return "get"; }
        }
        
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            var allParameters = new NameValueCollection();

            ParameterValidator.IsNotNull(PaymentMethodId, "PaymentMethodId");
            allParameters.Add("paymentMethodId", PaymentMethodId.ToString());

            return allParameters;
        }

        public Response Response { get { return (Response)response; } }


        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            PAYNLSDK.Objects.PaymentMethod pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.PaymentMethod>(RawResponse);
            Response r = new Response();
            r.PaymentMethod = pm;
            response = r;
        }
    }
}
