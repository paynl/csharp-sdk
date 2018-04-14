using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Merchant.Get
{
    public class Response : ResponseBase
    {
        public static Get.Response FromRawResponse(string response)
        {
            return JsonConvert.DeserializeObject<Get.Response>(response);
        }

        /// <summary>
        /// This array contains information whether the request was succesfull yes or no 
        /// </summary>
        [JsonProperty("request")]
        public ResultInfo request { get; set; }

        [JsonProperty("merchant")]
        public Merchant merchant { get; set; }

        /// <summary>
        /// The different ways of contacting the merchant 
        /// </summary>
        [JsonProperty("contactData")]
        public Contact contactData { get; set; }

        #region Models (SubClasses)
        public class ResultInfo
        {
            public string result { get; set; }
            public string errorId { get; set; }
            public string errorMessage { get; set; }
        }

        public class Merchant
        {
            public string merchantId { get; set; }

            /// <summary>
            /// Name of the Merchant
            /// </summary>
            /// <value>The name.</value>
            public string name { get; set; }

            /// <summary>
            /// The public name of the merchant
            /// </summary>
            /// <value>The name of the public.</value>
            public string publicName { get; set; }

            public string website { get; set; }

            /// <summary>
            /// The type of the merchant
            ///1 - BV.
            ///2 - LTD
            ///3 - Foundation
            ///4 - One man
            ///5 - VOF
            ///6 - CV
            ///7 - Maatschap
            ///8 - NV
            ///9 - Union
            ///10 - Coop
            /// </summary>
            /// <value>The type.</value>
            public string type { get; set; }

            public string typeName { get; set; }
            [JsonRequired] [Required] public string cocNumber { get; set; }
            public string vatNumber { get; set; }
            public string iban { get; set; }
            public string bic { get; set; }
            public string bankaccountHolder { get; set; }
            public Address postalAddress { get; set; }
            public Address visitAddress { get; set; }
            public Tradename[] tradeNames { get; set; }

            public class Address
            {
                public string street { get; set; }
                public string houseNumber { get; set; }
                public string zipCode { get; set; }
                public string city { get; set; }
                public string countryCode { get; set; }
                public string countryName { get; set; }
            }

            public class Tradename
            {
                public string id { get; set; }
                public string name { get; set; }
            }

            public class Contract
            {
                public string packageType { get; set; }
                public string invoiceAllowed { get; set; }
                public string payoutInterval { get; set; }
                public string createdDate { get; set; }
                public string acceptedDate { get; set; }
                public string deletedDate { get; set; }
            }

            public class Service
            {
                public string serviceId { get; set; }
                public string serviceName { get; set; }
            }

            public class Document
            {
                public string id { get; set; }
                public string type_id { get; set; }
                public string type_name { get; set; }
                public string status_id { get; set; }
                public string status_name { get; set; }
                public string expires { get; set; }
            }

            #endregion


            public class Account
            {
                public string id { get; set; }
                public string account_id { get; set; }
                public string name { get; set; }
                public string accepted { get; set; }
                public string access { get; set; }
                public string ubo { get; set; }
                public string authorised_to_sign { get; set; }
                public string signature_label { get; set; }
                public Document[] documents { get; set; }
            }
        }

        /// <summary>
        /// The type for the contact row. possible values:
        /// - email
        ///- email_support
        ///- email_msnskype
        ///- phone
        ///- phone_off_hours
        ///- phone_helpdesk
        ///- url
        /// </summary>
        public class Contact
        {
            public string type { get; set; }
            public string value { get; set; }
            public string description { get; set; }
        }

    }
}