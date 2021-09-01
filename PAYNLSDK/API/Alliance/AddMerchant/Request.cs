using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PAYNLSDK.API.Alliance.AddMerchant
{
    public class Request : RequestBase
    {
        public Request()
        {
            Accounts = new List<Account>();
        }

        /// <inheritdoc />
        protected override int Version => 6;
        /// <inheritdoc />
        protected override string Controller => "Alliance";
        /// <inheritdoc />
        protected override string Method => "addMerchant";
        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var retVal = new NameValueCollection { };

            retVal.Add("merchant[name]", FullName);
            retVal.Add("merchant[coc]", Coc);
            retVal.Add("merchant[vat]", Vat);
            retVal.Add("merchant[street]", Street);
            retVal.Add("merchant[houseNumber]", HouseNumber);
            retVal.Add("merchant[houseNumberAddition]", HouseNumberAddition);
            retVal.Add("merchant[postalCode]", PostalCode);
            retVal.Add("merchant[city]", City);
            retVal.Add("merchant[countryCode]", CountryCode);
            retVal.Add("merchant[contactEmail]", ContactEmail);
            retVal.Add("merchant[contactPhone]", ContactPhone);
            
            for (var i = 0; i < Accounts.Count; i++)
            {
                var account = Accounts[i];
                retVal.Add($"accounts[{i}][email]", account.Email);
                retVal.Add($"accounts[{i}][firstname]", account.FirstName);
                retVal.Add($"accounts[{i}][lastname]", account.LastName);
                retVal.Add($"accounts[{i}][gender]", account.Gender.ToString());
                retVal.Add($"accounts[{i}][authorizedToSign]", account.AuthorizedToSign.ToString());
                retVal.Add($"accounts[{i}][ubo]", account.UltimateBeneficialOwner ? "1" : "0");
                retVal.Add($"accounts[{i}][uboPercentage]", account.UboPercentage.ToString());
                retVal.Add($"accounts[{i}][useCompanyAuth]", account.UseCompanyAuth ? "1" : "0");
                retVal.Add($"accounts[{i}][hasAccess]", account.HasAccess ? "1" : "0");
                retVal.Add($"accounts[{i}][language]", account.Language);
            }

            if (BankAccount != null)
            {
                retVal.Add("bankaccount[BankAccountOwner]", BankAccount.BankAccountOwner);
                retVal.Add("bankaccount[BankAccountNumber]", BankAccount.BankAccountNumber);
                retVal.Add("bankaccount[BankAccountBIC]", BankAccount.BankAccountBic);
            }

            if (MerchantSettings != null)
            {
                retVal.Add("settings[package]", MerchantSettings.Package);
                retVal.Add("settings[sendEmail]", MerchantSettings.SendEmail);
                retVal.Add("settings[settleBalance]", MerchantSettings.SettleBalance ? "1" : "0");
                retVal.Add("settings[referralProfileId]", MerchantSettings.ReferralProfileId);
                retVal.Add("settings[clearingInterval]", MerchantSettings.ClearingInterval);
            }

            return retVal;
        }

        /// <summary>
        /// a phone number that customers can use to contact the merchant
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// an email address that customers can use to contact the merchant
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// Countrycode of the country where the company is located
        /// </summary>
        [Required]
        public string CountryCode { get; set; }

        /// <summary>
        /// City where the company is located
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Postcalcode of the company
        /// </summary>
        [Required]
        public string PostalCode { get; set; }

        /// <summary>
        /// Housenumber of the company
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Housenumber addition of the company
        /// </summary>
        public string HouseNumberAddition { get; set; }

        /// <summary>
        /// Name of the street the company is located
        /// </summary>
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// VAT number of the company
        /// </summary>
        [Required]
        public string Vat { get; set; }

        /// <summary>
        /// Chamber of Commerce number of the company
        /// </summary>
        /// 
        [JsonProperty("coc")]
        public string Coc { get; set; }

        /// <summary>
        /// Name of the company
        /// </summary>
        [JsonProperty("name")]
        public string FullName { get; set; }

        /// <summary>
        /// Array of accounts to be linked to the merchant. At least 1 account must be added
        /// </summary>
        public List<Account> Accounts { get; set; }

        public BankAccount BankAccount { get; set; }
        public MerchantSettings MerchantSettings { get; set; }


        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            // do nothing   
        }
    }

    public class MerchantSettings
    {
        /// <summary>
        /// Available options are day, week, month or manual
        /// </summary>
        public string ClearingInterval { get; set; }

        /// <summary>
        ///  ID of the default merchant settings to be applied to the new signup
        /// </summary>
        public string ReferralProfileId { get; set; }

        /// <summary>
        /// Available options are Alliance and AlliancePlus
        /// </summary>
        public string Package { get; set; }

        /// <summary>
        /// Indicates if the new merchant should receive a registration email. 0: No e-mail / 1: Regular registration e-mail / 2: Short registration e-mail
        /// </summary>
        public string SendEmail { get; set; }
        /// <summary>
        /// Whether or not to settle the alliance invoice with the merchants clearing. Available options: 0: No(default)  / 1: Yes
        /// </summary>
        public bool SettleBalance { get; set; }
    }

    /// <summary>
    /// A account linked which can be linked to a merchant
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Email address
        /// </summary>
        [JsonProperty("email")]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Given name
        /// </summary>
        [JsonProperty("firstname")]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Family name
        /// </summary>
        [JsonProperty("lastname")]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Available options are:
        /// M: male
        /// F: female
        /// </summary>
        [JsonProperty("gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// Indicates if the user is authorised to sign
        /// 0 not authorised, 1 authorised independently, 2  shared authorized to sign
        /// </summary>
        [JsonProperty("authorisedToSign")]
        [Required]
        public AuthorizedToSignEnum AuthorizedToSign { get; set; }

        /// <summary>
        /// Indicates if the user is ubo
        /// Ultimate beneficial owner (25% of more shares)
        /// </summary>
        [JsonProperty("ubo")]
        [Required]
        public bool UltimateBeneficialOwner { get; set; }

        /// <summary>
        /// If the user is UBO, use this parameter to set the percentage of UBO. Eg. 25 for 25%
        /// </summary>
        [JsonProperty("uboPercentage")]
        [Required]
        public int UboPercentage { get; set; }

        /// <summary>
        /// Indicates if the user has company rights. Available options are 0 and 1
        /// </summary>
        [Required]
        [JsonProperty("useCompanyAuth")]
        public bool UseCompanyAuth { get; set; }

        /// <summary>
        /// Indicates whether or not the account can login to the merchant's account. Available options:
        /// 1: Yes, account can access the merchant
        /// 0: No.Use this setting to add accounts that are only added to define the UBO's
        /// </summary>
        [Required]
        [JsonProperty("hasAccess")]
        public bool HasAccess { get; set; }

        /// <summary>
        /// Preferred language of the registrant. See API_Langauge_v2::getAll()
        /// </summary>
        [Required]
        [JsonProperty("language")]
        public string Language { get; set; }


        /// <summary>
        /// Gender of a person
        /// </summary>
        public enum GenderEnum
        {
            /// <summary>
            /// Male
            /// </summary>
            M,
            /// <summary>
            /// Female
            /// </summary>
            F
        }

        /// <summary>
        ///  Indicates if the user is authorized to sign.
        /// </summary>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public enum AuthorizedToSignEnum
        {
            /// <summary>
            /// No, not authorized
            /// </summary>
            NotAuthorized = 0,
            /// <summary>
            /// Yes, authorized to sign independently
            /// </summary>
            AuthorizedIndependently = 1,
            /// <summary>
            /// Yes, shared authorized to sign
            /// </summary>
            SharedAuthorizedToSign = 2
        }
    }

    public class BankAccount
    {
        /// <summary>
        /// Owner's name of the bankaccount
        /// </summary>
        public string BankAccountOwner { get; set; }
        /// <summary>
        /// Bank account number should be an IBAN
        /// </summary>
        public string BankAccountNumber { get; set; }
        /// <summary>
        /// BIC or SWIFT code
        /// </summary>
        public string BankAccountBic { get; set; }
    }
}
