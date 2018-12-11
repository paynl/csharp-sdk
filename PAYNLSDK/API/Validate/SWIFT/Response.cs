using Newtonsoft.Json;
using PAYNLSDK.Converters;
using System;

namespace PAYNLSDK.API.Validate.SWIFT
{
    /// <summary>
    /// Response of the <see cref="PAYNLSDK.API.Validate.SWIFT.Request"/>.
    /// Implements the <see cref="PAYNLSDK.API.ResponseBase" />
    /// </summary>
    /// <seealso cref="PAYNLSDK.API.ResponseBase" />
    public class Response : ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Response"/> is successful.
        /// </summary>
        /// <value><c>true</c> if successful; otherwise, <c>false</c>.</value>
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}
