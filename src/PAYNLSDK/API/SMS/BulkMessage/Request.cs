using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.SMS.BulkMessage
{
    public class Request : RequestBase
    {
        [JsonProperty("org")]
        public string Sender { get; set; }

        [JsonProperty("dest")]
        public string Recipient { get; set; }

        [JsonProperty("body")]
        public string Message { get; set; }

        //[JsonProperty("starttime")]
        //public int SendTime { get; set; }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "SMS"; }
        }

        public override string Method
        {
            get { return "sendBulkMessage"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters()
        {
            var nvc = base.GetParameters();

            ParameterValidator.IsNotEmpty(Sender, "Sender");
            nvc.Add("org", Sender);

            ParameterValidator.IsNotEmpty(Recipient, "Recipient");
            nvc.Add("dest", Recipient);

            ParameterValidator.IsNotEmpty(Message, "Message");
            nvc.Add("body", Message);

            return nvc;
        }
        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}
