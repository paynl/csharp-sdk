using Newtonsoft.Json;
using PAYNLSDK.Converters;
using System;

namespace PAYNLSDK.API.Validate.VAT
{

    /// <summary>
    /// Reponse of the <see cref="PAYNLSDK.API.Validate.VAT.Request"/>.
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
