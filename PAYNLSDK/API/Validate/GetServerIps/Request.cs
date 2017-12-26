using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Validate.GetServerIps
{
    public class Request : RequestBase
    {
        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "Validate"; }
        }

        public override string Method
        {
            get { return "getPayServerIps"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters()
        {
            return new NameValueCollection();
        }

        public Response Response { get { return (Response)response; } }

        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            string[] ips = JsonConvert.DeserializeObject<string[]>(RawResponse);
            Response r = new Response();
            r.IPAddresses = ips;
            response = r;
        }
    }
}
