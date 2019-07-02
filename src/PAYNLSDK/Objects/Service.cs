using Newtonsoft.Json;
using PAYNLSDK.Enums;

namespace PAYNLSDK.Objects
{
    /// <summary>
    ///  Service Details
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Service ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// Service Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Service Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The way the service is presented to the customer (eg. an URL or name of an advertisement) 
        /// </summary>
        [JsonProperty("publication")]
        public string Publication { get; set; }

        /// <summary>
        /// Base path of the images for the payment options 
        /// </summary>
        [JsonProperty("basePath")]
        public string BasePath { get; set; }

        /// <summary>
        /// ID of the module
        /// </summary>
        [JsonProperty("module")]
        public int Module { get; set; }

        /// <summary>
        /// ID of the submodule
        /// </summary>
        [JsonProperty("subModule")]
        public int SubModule { get; set; }

        /// <summary>
        /// Active state for this Service
        /// </summary>
        [JsonProperty("state")]
        public ActiveState State { get; set; }

        /// <summary>
        /// Target url after a successfull payment 
        /// </summary>
        [JsonProperty("successUrl")]
        public string SuccessUrl { get; set; }

        /// <summary>
        /// Target url after a failed payment
        /// </summary>
        [JsonProperty("errorUrl")]
        public string ErrorUrl { get; set; }
    }
}
