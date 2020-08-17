using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;
using System.Collections.Generic;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Payment Option information base
    /// </summary>
    abstract public class PaymentOptionBase
    {
        /// <summary>
        /// ID for this payment (sub)option
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; set; }

        /// <summary>
        /// Name for this payment (sub)option
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Visible name for this payment (sub)option
        /// </summary>
        [JsonProperty("visibleName")]
        public string VisibleName { get; set; }

        /// <summary>
        /// Image for this payment (sub)option
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// Indicator whether or not the sub option is available
        /// </summary>
        [JsonProperty("state")]
        public Availability State { get; set; }

    }

    /// <summary>
    /// Payment Suboption information
    /// </summary>
    public class PaymentSubOption : PaymentOptionBase
    {
    }

    /// <summary>
    /// Payment Suboptions Dictionary
    /// </summary>
    public class PaymentSubOptions : Dictionary<int, PaymentSubOption>
    {
    }

    /// <summary>
    /// Payment Option information
    /// </summary>
    public class PaymentOption : PaymentOptionBase
    {
        /// <summary>
        /// ID of the Payment Method this option belongs to
        /// </summary>
        [JsonProperty("paymentMethodId")]
        public PaymentMethodId PaymentMethodId { get; set; }

        /// <summary>
        /// Dictionary of payment sub options
        /// </summary>
        [JsonProperty("paymentOptionSubList")]
        public PaymentSubOptions PaymentSubOptions { get; set; }
    }

    /// <summary>
    /// Payment Options Dictionary
    /// </summary>
    public class PaymentOptions : Dictionary<int, PaymentOption>
    {
    }

}
