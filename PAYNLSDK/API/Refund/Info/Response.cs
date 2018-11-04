using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Refund.Info
{
    public class Response : ResponseBase
    {
        /// <summary>
        /// Refund information
        /// </summary>
        [JsonProperty("refund")]
        public RefundInfo Refund { get; protected set; }
    }
}
