using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Validate.IsPayServerIp
{
    public class Request : RequestBase
    {
        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }

        public override bool RequiresApiToken
        {
            get
            {
                return false;// base.RequiresApiToken;
            }
        }

        protected override int Version
        {
            get { return 1; }
        }

        protected override string Controller
        {
            get { return "Validate"; }
        }

        protected override string Method
        {
            get { return "isPayServerIp"; }
        }
        
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(IpAddress, "IpAddress");
            nvc.Add("ipAddress", IpAddress);

            return nvc;
        }

        public Response Response { get { return (Response)response; } }

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
