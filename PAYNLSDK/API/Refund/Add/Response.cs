using System;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Refund.Add
{
    public class Response : ResponseBase
    {
        /// <summary>
        /// ID of the refund starting with 'RF-' (optional, emptyfor creditcard transactions)
        /// </summary>
        [JsonProperty("refundId")]
        public string RefundId { get; set; }
    }
}
