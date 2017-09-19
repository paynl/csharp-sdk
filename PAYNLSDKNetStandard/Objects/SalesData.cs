using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;
using PAYNLSDK.Converters;
using System.Collections.Generic;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Specification of sales data for a transaction
    /// </summary>
    public class SalesData
    {
        /// <summary>
        /// Invoice date
        /// </summary>
        [JsonProperty("invoiceDate"), JsonConverter(typeof(DMYConverter))]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Delivery date
        /// </summary>
        [JsonProperty("deliveryDate"), JsonConverter(typeof(DMYConverter))]
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Ordered products specification
        /// </summary>
        [JsonProperty("orderData")]
        public List<OrderData> OrderData { get; set; }
    }
}
