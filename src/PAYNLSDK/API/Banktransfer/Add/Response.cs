using System;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Banktransfer.Add
{
    public class Response : ResponseBase
    {
        [JsonProperty("refundId")]
        public string RefundId { get; set; }
    }
}
