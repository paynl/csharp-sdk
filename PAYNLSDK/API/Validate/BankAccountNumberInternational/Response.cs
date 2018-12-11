using Newtonsoft.Json;
using PAYNLSDK.Converters;
using System;

namespace PAYNLSDK.API.Validate.BankAccountNumberInternational
{
    /// <summary>Class Response.
    /// Implements the <see cref="PAYNLSDK.API.ResponseBase"/></summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PAYNLSDK.API.Validate.BankAccountNumberInternational.Response" /> is succesful.
        /// </summary>
        /// <value><c>true</c> if succesful; otherwise, <c>false</c>.</value>
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool Result { get; protected set; }
    }
}
