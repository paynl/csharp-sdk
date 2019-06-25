using Newtonsoft.Json;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Service Category information
    /// </summary>
    public class ServiceCategory
    {
        /// <summary>
        /// ID of the Service Category
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the Service Category
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
