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

        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "SMS";

        /// <inheritdoc />
        protected override string Method => "sendBulkMessage";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(Sender, "Sender");
            nvc.Add("org", Sender);

            ParameterValidator.IsNotEmpty(Recipient, "Recipient");
            nvc.Add("dest", Recipient);

            ParameterValidator.IsNotEmpty(Message, "Message");
            nvc.Add("body", Message);

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
