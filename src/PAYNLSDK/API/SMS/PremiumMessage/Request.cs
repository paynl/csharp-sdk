using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.SMS.PremiumMessage
{
    public class Request : RequestBase
    {
        [JsonProperty("sms_id")]
        public string SmsId { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

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
            get { return "sendPremiumMessage"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters()
        {
            var nvc = base.GetParameters();

            ParameterValidator.IsNotEmpty(SmsId, "SmsId");
            nvc.Add("sms_id", SmsId);

            ParameterValidator.IsNotEmpty(Secret, "secret");
            nvc.Add("secret", Secret);

            ParameterValidator.IsNotEmpty(Message, "message");
            nvc.Add("message", Message);

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
