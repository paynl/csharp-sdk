using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Transaction.Start
{
    public class Response : ResponseBase
    {
        [JsonProperty("endUser")]
        public Enduser endUser { get; set; }
        [JsonProperty("transaction")]
        public Transaction transaction { get; set; }

        public class Enduser
        {
            public string blacklist { get; set; }
        }

        public class Transaction
        {
            public string transactionId { get; set; }
            public string paymentURL { get; set; }
            public string popupAllowed { get; set; }
            public string paymentReference { get; set; }
        }

    }
}

