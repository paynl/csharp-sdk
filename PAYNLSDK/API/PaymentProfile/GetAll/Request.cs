using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.PaymentProfile.GetAll
{
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "PaymentProfile";

        /// <inheritdoc />
        protected override string Method => "getAll";

        public override NameValueCollection GetParameters()
        {
            return new NameValueCollection();
        }

        public Response Response => (Response)response;

        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            PAYNLSDK.Objects.PaymentProfile[] pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.PaymentProfile[]>(RawResponse);
            Response r = new Response
            {
                PaymentProfiles = pm
            };
            response = r;
        }
    }
}
