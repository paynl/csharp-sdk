using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Transaction.GetLastTransactions
{
    public class Response : ResponseBase
    {
        [JsonProperty("arrStatsData")]
        public TransactionStatsList TransactionStats { get; set; }
    }
}
