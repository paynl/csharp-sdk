using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Transaction.GetService
{
    public class Response : ResponseBase
    {
        [JsonProperty("merchant")]
        public Merchant Merchant { get; set; }

        [JsonProperty("service")]
        public Objects.Service Service { get; set; }

        [JsonProperty("countryOptionList")]
        public CountryOptions CountryOptions { get; set; }
    }
}
