using System;
using Newtonsoft.Json;
using PAYNLSDK.Converters;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Transaction data
    /// </summary>
    public class TransactionData
    {
        /// <summary>
        /// The currency of the transaction. If omitted, EUR is used.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Cost for VAT
        /// </summary>
        [JsonProperty("costsVat")]
        public int? CostsVat { get; set; }

        // No documentation is available to implement this
        //[JsonProperty("excludeCosts")]
        //public Array ExcludeCosts { get; set; }

        /// <summary>
        /// The URL of the exchange file that needs to be called
        /// </summary>
        [JsonProperty("orderExchangeUrl")]
        public string OrderExchangeUrl { get; set; }

        /// <summary>
        /// Description belonging to the order
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Expire date of the transaction
        /// </summary>
        [JsonProperty("expireDate")]
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// The number belonging to the order
        /// </summary>
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        /// <summary>
        ///  	Unique id of the enduser
        /// </summary>
        [JsonProperty("enduserId")]
        public int? EnduserId { get; set; }
        
        /// <summary>
        /// Whether to sent a confimation email
        /// </summary>
        [JsonProperty("sendReminderEmail"), JsonConverter(typeof(BooleanConverter))]
        public bool SendReminderEmail { get; set; }

        /// <summary>
        /// The id of mailtemplate in case a confirmation mail needs to be sent
        /// </summary>
        [JsonProperty("reminderMailTemplateId")]
        public int? ReminderMailTemplateId { get; set; }


    }
}
