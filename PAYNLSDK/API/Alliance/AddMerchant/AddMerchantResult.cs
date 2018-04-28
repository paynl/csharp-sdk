using Newtonsoft.Json;
using PAYNLSDK.Converters;

namespace PAYNLSDK.API.Alliance.AddMerchant
{
    /// <summary>
    ///     Class AddMerchantResult.
    /// </summary>
    /// <remarks>
    /// working url: https://rest-api.pay.nl/v4/Alliance/addMerchant/json?merchant[name]=Damiaan+Peeters&merchant[coc]=0881275682&merchant[vat]=BE0881275682&merchant[street]=borsbeeksebrug&merchant[houseNumber]=6&merchant[houseNumberAddition]=64&merchant[postalCode]=2600&merchant[city]=Berchem&merchant[countryCode]=BE&accounts[0][email]=damiaan.peeters%40gmail.com&accounts[0][firstname]=Voornaam&accounts[0][lastname]=Achternaam&accounts[0][gender]=M&accounts[0][authorizedToSign]=1&accounts[0][ubo]=0&accounts[0][uboPercentage]=0&accounts[0][useCompanyAuth]=1&accounts[0][hasAccess]=1&accounts[0][language]=1
    /// </remarks>
    public class AddMerchantResult
    {
        /// <summary>
        ///     Gets or sets if it was success.
        /// </summary>
        /// <value>whether we had a succesfull call or not.</value>
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