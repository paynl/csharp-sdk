using Newtonsoft.Json;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Company information, used in the enduser.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// The name of the company
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The COC number of the company
        /// </summary>
        [JsonProperty("cocNumber")]
        public string CocNumber { get; set; }

        /// <summary>
        /// The VAT number of the company
        /// </summary>
        [JsonProperty("vatNumber")]
        public string VatNumber { get; set; }

        /// <summary>
        /// ID of the country (2 char country code)
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}
