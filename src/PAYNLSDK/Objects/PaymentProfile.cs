using Newtonsoft.Json;
using PAYNLSDK.Converters;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Payment Profile information
    /// </summary>
    public class PaymentProfile
    {
        /// <summary>
        /// Payment Profile ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Payment Profile Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Payment Profile Parent ID
        /// </summary>
        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        /// <summary>
        /// Indicator if this Payment Profile is publicly available
        /// </summary>
        [JsonProperty("public"), JsonConverter(typeof(BooleanConverter))]
        public bool Public { get; set; }

        /// <summary>
        /// Payment Method ID this profile belongs to
        /// </summary>
        [JsonProperty("payment_method_id")]
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// Country ID this payment profile belongs to.
        /// </summary>
        [JsonProperty("country_id")]
        public int CountryId { get; set; }

        /// <summary>
        /// ID of the Payment Tariff
        /// </summary>
        [JsonProperty("payment_tariff_id")]
        public int PaymentTariffId { get; set; }

        /// <summary>
        /// The nature of address, mostly used for PayPerCall and PayPerMinute to indicate wether this the payment was done with a mobile phone (1) or not (0). 
        /// </summary>
        [JsonProperty("noah_id")]
        public int NoahId { get; set; }
    }
}
