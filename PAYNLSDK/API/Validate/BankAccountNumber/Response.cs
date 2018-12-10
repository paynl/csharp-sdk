using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using PAYNLSDK.Converters;

namespace PAYNLSDK.API.Validate.BankAccountNumber
{
    /// <summary>
    /// The reponse object for the bank account number validation
    /// </summary>
    public class Response : ResponseBase
    {
        /// <summary>
        /// the result from the bank account number validation
        /// </summary>
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public bool result { get; protected set; }
    }
}
