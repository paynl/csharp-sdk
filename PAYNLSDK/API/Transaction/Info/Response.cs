using System;
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

        /// <summary>
        /// All details from the payment
        /// </summary>
        [JsonProperty("paymentDetails")]
        public PaymentDetails PaymentDetails { get; protected set; }

        /// <summary>
        /// Details regarding the refund (if any)
        /// </summary>
        [JsonProperty("stornoDetails")]
        public StornoDetails StornoDetails { get; protected set; }

        [JsonProperty("statsDetails")]
        public StatsDetails StatsDetails { get; protected set; }

    }
}
