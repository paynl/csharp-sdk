using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;
using PAYNLSDK.Enums;
using PAYNLSDK.Converters;
using System.Collections.Generic;

namespace PAYNLSDK.API.Transaction.ChangeStatusList
{
    public class Response : ResponseBase
    {
        [JsonProperty("moreData"), JsonConverter(typeof(BooleanConverter))]
        public bool HasMoreData { get; protected set; }

        [JsonProperty("firstChangeStamp"), JsonConverter(typeof(TimestampConverter))]
        public DateTime? FirstChange { get; protected set; }

        [JsonProperty("lastChangeStamp"), JsonConverter(typeof(TimestampConverter))]
        public DateTime? LastChange { get; protected set; }

        [JsonProperty("numberOfTransactions")]
        public int NumberOfTransactions { get; protected set; }

        [JsonProperty("transactions")]
        public List<ChangeStatusListTransactionDetails> Transactions { get; protected set; }
    }
}
