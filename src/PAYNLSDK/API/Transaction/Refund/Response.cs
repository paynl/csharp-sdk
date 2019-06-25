using Newtonsoft.Json;
using System;

namespace PAYNLSDK.API.Transaction.Refund
{
    public class Response : ResponseBase
    {
        [JsonProperty("refundId")]
        public string RefundId { get; protected set; }
    }
}
