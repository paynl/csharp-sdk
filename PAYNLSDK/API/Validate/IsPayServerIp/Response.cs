using Newtonsoft.Json;
using PAYNLSDK.Converters;
using System;

namespace PAYNLSDK.API.Validate.IsPayServerIp
{
    /// <summary>
    /// Response for the <see cref="PAYNLSDK.API.Validate.IsPayServerIp.Request"/>.
    /// Implements the <see cref="PAYNLSDK.API.ResponseBase" />
    /// </summary>
    /// <seealso cref="PAYNLSDK.API.ResponseBase" />
    public class Response : ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Response"/> is succesful.
        /// </summary>
        /// <value><c>true</c> if succesful; otherwise, <c>false</c>.</value>
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}
