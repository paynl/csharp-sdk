using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Connection information
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Trust indicator, from -10 to 10
        /// </summary>
        [JsonProperty("trust")]
        public int? Trust { get; protected set; }

        /// <summary>
        /// Country code fo the customer
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; protected set; }

        /// <summary>
        /// name of the city of the customer 
        /// </summary>
        [JsonProperty("city")]
        public string City { get; protected set; }

        /// <summary>
        /// Customer location, latitude
        /// </summary>
        [JsonProperty("locationLat")]
        public string LocationLat { get; protected set; }

        /// <summary>
        /// Customer location, longitude
        /// </summary>
        [JsonProperty("locationLon")]
        public string LocationLon { get; protected set; }

        /// <summary>
        /// Details of the cusomers browser. Specified on transaction start 
        /// </summary>
        [JsonProperty("browserData")]
        public string BrowserData { get; protected set; }

        /// <summary>
        /// IP address of the customer (during payment) 
        /// </summary>
        [JsonProperty("ipAddress")]
        public string IP { get; protected set; }

        /// <summary>
        /// Indicator whether or not the cusomer is blacklisted
        /// </summary>
        [JsonProperty("blacklist")]
        public Blacklist? Blacklist { get; protected set; }

        /// <summary>
        /// Hostaddress of the customer
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; protected set; }

        /// <summary>
        /// Ip used in the order
        /// </summary>
        [JsonProperty("orderIpAddress")]
        public string OrderIP { get; protected set; }

        /// <summary>
        /// Used return URl in request
        /// </summary>
        [JsonProperty("orderReturnUrl")]
        public string OrderReturnUrl { get; protected set; }

        /// <summary>
        /// The corresponding merchant-code of the merchant
        /// </summary>
        [JsonProperty("merchantCode")]
        public string MerchantCode { get; protected set; }

        /// <summary>
        /// The corresponding name of the merchant
        /// </summary>
        [JsonProperty("merchantName")]
        public string MerchantName { get; protected set; }
    }
}
