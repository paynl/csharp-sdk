using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;
using PAYNLSDK.Converters;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Provides details of the EndUser.
    /// </summary>
    public class EndUser
    {
        // @DISABLED@
        //[JsonProperty("accessCode")]
        //public string AccessCode { get; set; }

        /// <summary>
        /// Unique reference of customer
        /// </summary>
        [JsonProperty("customerReference")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// End User's Language
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// End User's Initials
        /// </summary>
        [JsonProperty("initials")]
        public string Initials { get; set; }

        /// <summary>
        /// End User's Gender
        /// </summary>
        [JsonProperty("gender"), JsonConverter(typeof(GenderConverter))]
        public Gender? Gender { get; set; }

        /// <summary>
        /// End User's Last Name
        /// </summary>
        [JsonProperty("lastName")]
        public string Lastname { get; set; }

        /// <summary>
        /// End User's Date of Birth
        /// </summary>
        [JsonProperty("dob"), JsonConverter(typeof(DMYConverter))]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// End User's Phone Number
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// End User's Email Address
        /// </summary>
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// End User's Bank Account Number.
        /// Note in most cases the IBAN will be used.
        /// </summary>
        [JsonProperty("bankAccount")]
        public string BankAccount { get; set; }

        /// <summary>
        /// End User's IBAN
        /// </summary>
        [JsonProperty("iban")]
        public string IBAN { get; set; }

        /// <summary>
        /// End User's BIC
        /// </summary>
        [JsonProperty("bic")]
        public string BIC { get; set; }

        [JsonProperty("sendConfirmMail")]
        public bool? SendConfirmMail { get; set; }

        //[JsonProperty("confirmMailTemplate")]
        //public string ConfirmMailTemplate { get; set; }

        /// <summary>
        /// End User's Address
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; set; }

        /// <summary>
        /// End User's Invoice Address
        /// </summary>
        [JsonProperty("invoiceAddress")]
        public Address InvoiceAddress { get; set; }

        //[JsonProperty("saleData")]
        //public SaleData? SalesData { get; protected set; }

        /// <summary>
        /// End User's Payment Details
        /// </summary>
        [JsonProperty("paymentDetails")]
        public PaymentDetails PaymentDetails { get; set; }

        /// <summary>
        /// End User's Storno Details if applicable
        /// </summary>
        [JsonProperty("stornoDetails")]
        public StornoDetails StornoDetails { get; set; }

        /// <summary>
        /// End User's Stats Details if applicable
        /// </summary>
        [JsonProperty("statsDetails")]
        public StatsDetails StatsDetails { get; set; }

        /// <summary>
        /// Company information of the EndUser
        /// </summary>
        [JsonProperty("company")]
        public Company Company { get; set; }
    }
}
