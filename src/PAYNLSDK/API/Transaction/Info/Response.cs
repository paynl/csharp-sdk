using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Transaction.Info
{
    public class Response : ResponseBase
    {
        [JsonProperty("connection")]
        public Connection Connection { get; protected set; }

        [JsonProperty("enduser")]
        public EndUser EndUser { get; protected set; }

        //[JsonProperty("saledata")]
        //public SalesData SalesData { get; protected set; }

        [JsonProperty("paymentDetails")]
        public PaymentDetails PaymentDetails { get; protected set; }

        [JsonProperty("stornoDetails")]
        public StornoDetails StornoDetails { get; protected set; }

        [JsonProperty("statsDetails")]
        public StatsDetails StatsDetails { get; protected set; }
    }
}
