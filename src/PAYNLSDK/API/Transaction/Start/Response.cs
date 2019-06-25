using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Transaction.Start
{
    public class Response : ResponseBase
    {
        [JsonProperty("enduser")]
        public TransactionStartEnduser Enduser { get; set; }

        [JsonProperty("transaction")]
        public TransactionStartInfo Transaction { get; set; }

    }
}
