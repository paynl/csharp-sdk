using Newtonsoft.Json;

namespace PAYNLSDK.API.Alliance.AddService
{
    /// <summary>
    ///     Class result class for a Add Service call
    /// </summary>
    public class AddServiceResult : ResponseBase
    {
        /// <summary>
        /// The newly created service identifier (SL-****-****)
        /// </summary>
        [JsonProperty("serviceId")]
        public string ServiceId { get; set; }
    }
}