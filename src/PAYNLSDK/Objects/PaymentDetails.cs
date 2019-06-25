using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;
using PAYNLSDK.Converters;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Generl dtails regarding the payment
    /// </summary>
    public class PaymentDetails
    {
        /// <summary>
        /// Amount of the session (in cents, eg. 1235)
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; protected set; }

        /// <summary>
        /// Currency Amount of the session (in cents, eg. 1235) 
        /// </summary>
        [JsonProperty("currencyAmount")]
        public int CurrencyAmount { get; protected set; }

        /// <summary>
        /// The total amount paid for this transaction
        /// </summary>
        [JsonProperty("paidAmount")]
        public string PaidAmount { get; protected set; }

        /// <summary>
        /// The total currency amount paid for this transaction
        /// </summary>
        [JsonProperty("paidCurrencyAmount")]
        public string PaidCurrencyAmount { get; protected set; }

        /// <summary>
        /// Basic amount without the cost
        /// </summary>
        [JsonProperty("paidBase")]
        public string PaidBase { get; protected set; }

        /// <summary>
        /// Payment costs paid by the customer (ex. VAT) 
        /// </summary>
        [JsonProperty("paidCosts")]
        public string PaidCosts { get; protected set; }

        /// <summary>
        /// VAT rate for costs 
        /// </summary>
        [JsonProperty("paidCostsVat")]
        public string PaidCostsVat { get; protected set; }

        /// <summary>
        /// Currency of the payment 
        /// </summary>
        [JsonProperty("paidCurreny")]
        public string PaidCurreny { get; protected set; }

        /// <summary>
        /// Number of payment attempts 
        /// </summary>
        [JsonProperty("paidAttemps")]
        public string PaidAttemps { get; protected set; }

        /// <summary>
        /// Duration of the phonecall (only for phone payments)
        /// </summary>
        [JsonProperty("paidDuration")]
        public string PaidDuration { get; protected set; }

        /// <summary>
        /// Order description 
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; protected set; }

        /// <summary>
        /// Time passed from payment start to payment finish
        /// </summary>
        [JsonProperty("processTime")]
        public string ProcessTime { get; protected set; }

        /// <summary>
        /// Payment Status indicator
        /// </summary>
        [JsonProperty("state")]
        public PaymentStatus State { get; protected set; }

        /// <summary>
        /// Payment status name
        /// </summary>
        [JsonProperty("stateName")]
        public string StateName { get; protected set; }

        /// <summary>
        /// Payment status description
        /// </summary>
        [JsonProperty("stateDescription")]
        public string StateDescription { get; protected set; }

        /// <summary>
        /// Indicator whether or not the exchange URL has been called succesfully
        /// </summary>
        [JsonProperty("exchange")]
        //public ExchangeState Exchange { get; protected set; }
        public string Exchange { get; protected set; }

        /// <summary>
        /// Indicator whether or not the transaction is refunded
        /// </summary>
        [JsonProperty("storno"), JsonConverter(typeof(BooleanConverter))]
        public bool Storno { get; protected set; }

        /// <summary>
        /// The payment options used (eq. iDeal/creditcard) 
        /// </summary>
        [JsonProperty("paymentOptionId")]
        public int PaymentOptionId { get; protected set; }

        /// <summary>
        /// The payment options sub id used (eq. the selected bank for iDeal) 
        /// </summary>
        [JsonProperty("paymentOptionSubId")]
        public int PaymentOptionSubId { get; protected set; }

        /// <summary>
        /// For creditcard transactions
        /// </summary>
        [JsonProperty("secure")]
        public Secure Secure { get; protected set; }

        /// <summary>
        /// Returns the 3d secure status
        /// </summary>
        [JsonProperty("secureStatus")]
        public string SecureStatus { get; protected set; }

        /// <summary>
        /// Name of the consumer
        /// </summary>
        [JsonProperty("identifierName")]
        public string IdentifierName { get; protected set; }

        /// <summary>
        /// Payment identifier that can be displayed to the customer for reference
        /// </summary>
        [JsonProperty("identifierPublic")]
        public string IdentifierPublic { get; protected set; }

        /// <summary>
        /// Customer ID, a unique hash based upon the bankaccount/creditcard number of the customer
        /// </summary>
        [JsonProperty("identifierHash")]
        public string IdentifierHash { get; protected set; }

        /// <summary>
        /// ID of the service/website for which the transaction is started
        /// </summary>
        [JsonProperty("serviceId")]
        public string ServiceId { get; protected set; }

        /// <summary>
        /// Name of the service/website
        /// </summary>
        [JsonProperty("serviceName")]
        public string ServiceName { get; protected set; }

        /// <summary>
        /// Description of the service/website
        /// </summary>
        [JsonProperty("serviceDescription")]
        public string ServiceDescription { get; protected set; }

        /// <summary>
        /// Date time of the moment the transaction was started
        /// </summary>
        [JsonProperty("created")]
        public string Created { get; protected set; }

        /// <summary>
        /// Date time of the last status change of the transaction
        /// </summary>
        [JsonProperty("modified")]
        public string Modified { get; protected set; }

        /// <summary>
        /// ID of the type of the payment method
        /// </summary>
        [JsonProperty("paymentMethodId")]
        public string PaymentMethodId { get; protected set; }

        /// <summary>
        /// Name of the type of the payment method
        /// </summary>
        [JsonProperty("paymentMethodName")]
        public string PaymentMethodName { get; protected set; }

        /// <summary>
        /// Description of the type of the payment method
        /// </summary>
        [JsonProperty("paymentMethodDescription")]
        public string PaymentMethodDescription { get; protected set; }

        /// <summary>
        /// Name of the payment profile used to pay the transaction
        /// </summary>
        [JsonProperty("paymentProfileName")]
        public string PaymentProfileName { get; protected set; }

    }
}
