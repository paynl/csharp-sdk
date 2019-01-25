using Newtonsoft.Json;
using PAYNLSDK.Converters;

namespace PAYNLSDK.API.Alliance.AddMerchant
{
    /// <summary>
    /// The result of the Alliance/AddMerchant call
    /// </summary>
    public class AddMerchantResult
    {
        /// <summary>
        ///     Gets or sets if it was success.
        /// </summary>
        /// <value>whether we had a successful call or not.</value>
        [JsonProperty("success")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool Success { get; set; }

        /// <summary>
        ///     Gets or sets the error id
        /// </summary>
        /// <value>The error field.</value>
        [JsonProperty("error_field")]
        public string ErrorField { get; set; }

        /// <summary>
        ///     Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     Gets or sets the merchant identifier.
        /// </summary>
        /// <value>The merchant identifier.</value>
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        ///     Gets or sets the merchant token.
        /// </summary>
        /// <value>The merchant token.</value>
        [JsonProperty("merchantToken")]
        public string MerchantToken { get; set; }

        /// <summary>
        ///     The created accounts for this merchant
        /// </summary>
        [JsonProperty("accounts")]
        public Account[] Accounts { get; set; }

        /// <summary>
        ///     Class Account.
        /// </summary>
        public class Account
        {
            /// <summary>
            ///     Gets or sets the account identifier.
            /// </summary>
            /// <value>The account identifier.</value>
            [JsonProperty("accountId")]
            public string AccountId { get; set; }

            /// <summary>
            ///     Gets or sets the email.
            /// </summary>
            /// <value>The email.</value>
            [JsonProperty("email")]
            public string Email { get; set; }
        }
    }
}
