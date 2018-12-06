using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.PaymentMethod.GetAll
{
    /// <summary>
    /// This function returns an array containing all payment methods. 
    /// https://admin.pay.nl/docpanel/api/PaymentMethod/getAll/1
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "PaymentMethod";

        /// <inheritdoc />
        protected override string Method => "getAll";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            return new NameValueCollection();
        }

        public Response Response => (Response)response;

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            PAYNLSDK.Objects.PaymentMethod[] pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.PaymentMethod[]>(RawResponse);
            Response r = new Response
            {
                PaymentMethods = pm
            };
            response = r;
        }
    }
}
