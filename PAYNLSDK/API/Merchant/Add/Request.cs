using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Merchant.Add
{
    public class Request : RequestBase
    {
        /**
         * Add a merchant
         *
         * Create a new submerchant.
         * The format of the option array is as follows
         * array(
         *      // Required
         *      'companyName' => 'The Name',
         *      'cocNumber' => '123456789',
         *      'street' => 'Street',
         *      'houseNumber' => '123',
         *      'postalCode' => '1234 AA',
         *      'city' => 'City',
         *      'accounts' => array(
         *          // Minimum of 1 account, you can add more, one account must be primary, the other accounts cannot be primary
         *          array(
         *              'primary' => true, // One account must be primary
         *              'email' => 'email@test.nl',
         *              'firstname' => 'First',
         *              'lastname' => 'Last',
         *              'gender' => 'male', // 'male' or 'female'
         *              'authorisedToSign' => 2, //0 not authorised, 1 authorised independently, 2  shared authorized to sign
         *              'ubo' => true, // Ultimate beneficial owner (25% of more shares)
         *          ),
         *          array(
         *              'primary' => false,
         *              'email' => 'email2@test.nl',
         *              'firstname' => 'Mede',
         *              'lastname' => 'Eigenaar',
         *              'gender' => 'female', // 'male' or 'female'
         *              'authorisedToSign' => 2, //0 not authorised, 1 authorised independently, 2  shared authorized to sign
         *              'ubo' => true, // Ultimate beneficial owner (25% of more shares)
         *          )
         *       ),
         *      // Optional
         *      Do you want to send a registration email to the accounts.
         *      The options are:
         *      0 - No email is sent
         *      1 - The default registration email is sent
         *      2 - The shortened alliance registration email is sent
         *      'sendEmail' => 1, // see above
         *      'countryCode' => 'NL',
         *      'bankAccountOwner' => 'Firstname Lastname',
         *      'bankAccountNumber' => 'NL91ABNA0417164300',
         *      'bankAccountBIC' => 'ABNANL2A',
         *      'vatNumber' => 'NL123412413',
         *      'packageName' => 'Alliance', // Alliance or AlliancePlus
         *
         *      Set to true if you want to be able to add a debit invoice to the account of this merchant.
         *      Your invoice will be subtracted from the merchants account.
         *      You will need to ask the merchant for permission before you can set this value to true
         *      'settleBalance' => false, // see above
         *      'payoutInterval' => 'week' //day, week or month
         *  )
         */

        public string CompanyName { get; set; }
        public string CocNumber { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public List<Account> Accounts { get; set; }
        /// <summary>
        /// Optional
        ///      Do you want to send a registration email to the accounts.
        /// The options are:
        ///      0 - No email is sent
        ///      1 - The default registration email is sent
        ///      2 - The shortened alliance registration email is sent
        /// </summary>
        [JsonProperty("sendEmail")]
        public int? SendEmail { get; set; }

        [JsonProperty("countryCode")]
        public string TwoLetterCountryCode { get; set; }

        [JsonProperty("bankAccountOwner")]
        public string BankAccountOwner { get; set; }

        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        [JsonProperty("bankAccountBIC")]
        public string BankAccountBic { get; set; }

        [JsonProperty("vatNumber")]
        public string VatNumber { get; set; }

        /// <summary>
        /// Alliance or AlliancePlus
        /// </summary>
        [JsonProperty("packageName")]
        public string PackageName { get; set; }
        /// <summary>
        /// settleBalance
        /// Set to true if you want to be able to add a debit invoice to the account of this merchant.
        /// Your invoice will be subtracted from the merchants account.
        /// You will need to ask the merchant for permission before you can set this value to true
        /// </summary>
        [JsonProperty("settleBalance")]
        public bool SettleBalance { get; set; }

        /// <summary>
        /// options are day, week or month
        /// </summary>
        [JsonProperty("payoutInterval")]
        public string PayoutInterval { get; set; }

        internal class Account
        {
            [JsonProperty("primary")]
            public bool Primary { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("firstname")]
            public string FirstName { get; set; }

            [JsonProperty("lastname")]
            public string LastName { get; set; }

            /// <summary>
            /// "male" or "female"
            /// </summary>
            [JsonProperty("gender")]
            public string Gender { get; set; }

            /// <summary>
            /// 0 not authorised, 1 authorised independently, 2  shared authorized to sign
            /// </summary>
            [JsonProperty("authorisedToSign")]
            public int AuthorizedToSign { get; set; }

            /// <summary>
            /// Ultimate beneficial owner (25% of more shares)
            /// </summary>
            [JsonProperty("ubo")]
            public bool UltimateBeneficialOwner { get; set; }
        }

        public override int Version { get; }
        public override string Controller => "Merchant";
        public override string Method => "Add";
        

        public override NameValueCollection GetParameters()
        {
            // TODO
            throw new NotImplementedException();
        }

        protected override void PrepareAndSetResponse()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
