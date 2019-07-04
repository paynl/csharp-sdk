using Newtonsoft.Json;
using PAYNLSDK.Converters;
using System.Collections.Generic;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// General Payment options details for an individual country.
    /// </summary>
    public class CountryOption
    {
        /// <summary>
        /// Country option ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Country visible name
        /// </summary>
        [JsonProperty("visibleName")]
        public string VisibleName { get; set; }

        /// <summary>
        /// Filename of the country icon 
        /// </summary>
        [JsonProperty("img")]
        public string Image { get; set; }

        /// <summary>
        /// Path for the country icon. The full icon URL is a concatenation of $basePath, $path and $img. 
        /// </summary>
        [JsonProperty("path")]
        public string IconPath { get; set; }

        /// <summary>
        /// Indicator whether or not the country is located in the EU.
        /// </summary>
        [JsonProperty("in_eu"), JsonConverter(typeof(BooleanConverter))]
        public bool InEU { get; protected set; }

        /// <summary>
        /// List of available payment options for this country
        /// </summary>
        [JsonProperty("paymentOptionList")]
        public PaymentOptions PaymentOptions { get; set; }
    }

    /// <summary>
    /// Country Options
    /// </summary>
    public class CountryOptions : Dictionary<string, CountryOption>
    {
    }
}
