using System;
using Newtonsoft.Json;
using PAYNLSDK.Enums;
using PAYNLSDK.Converters;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// General Address Details
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Initials for Address
        /// </summary>
        [JsonProperty("initials")]
        public string Initials { get; set; }

        /// <summary>
        /// Lastname of receiver
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gender of receiver
        /// </summary>
        [JsonProperty("gender"), JsonConverter(typeof(GenderConverter))]
        public Gender? Gender { get; set; }

        /// <summary>
        /// Street name
        /// </summary>
        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        /// <summary>
        /// Street number
        /// </summary>
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Zipcode
        /// </summary>
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// ISO2 Country code
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

}
