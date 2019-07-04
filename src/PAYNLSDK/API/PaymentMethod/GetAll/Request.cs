using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.PaymentMethod.GetAll
{
    public class Request : RequestBase
    {
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
            get { return "getAll"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            var pm = JsonConvert.DeserializeObject<Objects.PaymentMethod[]>(RawResponse);
            var r = new Response
            {
                PaymentMethods = pm
            };
            response = r;
        }
    }
}
