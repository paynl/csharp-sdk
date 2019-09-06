using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Transaction.Details
{
    public class Response : ResponseBase
    {
        [JsonProperty("paymentDetails")]
        public TransactionDetailsPaymentDetails PaymentDetails { get; protected set; }
    }
}
