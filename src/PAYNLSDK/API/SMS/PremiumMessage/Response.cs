using Newtonsoft.Json;
using PAYNLSDK.Converters;

namespace PAYNLSDK.API.SMS.PremiumMessage
{
    public class Response : ResponseBase
    {
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}
