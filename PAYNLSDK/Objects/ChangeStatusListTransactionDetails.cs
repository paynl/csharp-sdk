using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;
using PAYNLSDK.Converters;
using System.Collections.Generic;

namespace PAYNLSDK.Objects
{
    public class ChangeStatusListTransactionDetails
    {
        /// <summary>
        /// The scrambled id of the transaction.
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; protected set; }

        /// <summary>
        /// The order id of the transaction.
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; protected set; }

        /// <summary>
        /// The order number of the transaction.
        /// </summary>
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; protected set; }

        /// <summary>
        /// ID of the payment profile used to pay the transaction
        /// </summary>
        [JsonProperty("paymentProfileId")]
        public int? PaymentProfileId { get; protected set; }

        /// <summary>
        /// Name of the payment profile used to pay the transaction
        /// </summary>
        [JsonProperty("paymentProfileName")]
        public string PaymentProfileName { get; protected set; }

        /// <summary>
        /// Payment Status indicator
        /// </summary>
        [JsonProperty("state")]
        public PaymentStatus? State { get; protected set; }

        /// <summary>
        /// Payment status name
        /// </summary>
        [JsonProperty("stateName")]
        public string StateName { get; protected set; }

        /// <summary>
        /// Amount of the session (in cents, eg. 1235)
        /// </summary>
        [JsonProperty("amountOriginal")]
        public CurrencyAmount AmountOriginal { get; protected set; }

        /// <summary>
        /// Amount of the session (in cents, eg. 1235)
        /// </summary>
        [JsonProperty("amount")]
        public CurrencyAmount Amount { get; protected set; }

        /// <summary>
        /// Amount of the session (in cents, eg. 1235)
        /// </summary>
        [JsonProperty("amountPaidOriginal")]
        public CurrencyAmount AmountPaidOriginal { get; protected set; }

        /// <summary>
        /// Amount of the session (in cents, eg. 1235)
        /// </summary>
        [JsonProperty("amountPaid")]
        public CurrencyAmount AmountPaid { get; protected set; }

        /// <summary>
        /// Amount of the session (in cents, eg. 1235)
        /// </summary>
        [JsonProperty("amountRefundOriginal")]
        public CurrencyAmount AmountRefundOriginal { get; protected set; }

        /// <summary>
        /// Amount of the session (in cents, eg. 1235)
        /// </summary>
        [JsonProperty("amountRefund")]
        public CurrencyAmount AmountRefund { get; protected set; }

        [JsonProperty("created"), JsonConverter(typeof(TimestampConverter))]
        public DateTime? Created { get; protected set; }

        [JsonProperty("modified"), JsonConverter(typeof(TimestampConverter))]
        public DateTime? Modified { get; protected set; }
    }
}
