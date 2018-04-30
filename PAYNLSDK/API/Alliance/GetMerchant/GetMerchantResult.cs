using System;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Alliance.GetMerchant
{
    /// <summary>
    /// The result of the Alliance/GetMerchant call
    /// </summary>
    public class GetMerchantResult
    {
        [JsonProperty("request")] public GetMerchantResult.Request request { get; set; }
        [JsonProperty("merchantId")] public string merchantId { get; set; }
        [JsonProperty("merchantName")] public string merchantName { get; set; }
        [JsonProperty("services")] public Service[] services { get; set; }
        [JsonProperty("balance")] public int BalanceInCents { get; set; }
        [JsonIgnore] public decimal Balance => Math.Round(BalanceInCents / 100m);
        [JsonProperty("documents")] public Document[] documents { get; set; }
        [JsonProperty("accounts")] public Account[] accounts { get; set; }
        [JsonProperty("bankaccounts")] public string bankaccounts { get; set; }
        [JsonProperty("public_info")] public Public_Info public_info { get; set; }
        [JsonProperty("contract")] public Contract contract { get; set; }

        public class Request
        {
            [JsonProperty("result")] public string result { get; set; }
            [JsonProperty("errorId")] public string errorId { get; set; }
            [JsonProperty("errorMessage")] public string errorMessage { get; set; }
        }

        public class Public_Info
        {
            public string merchantId { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string typeName { get; set; }
            public Postaladdress postalAddress { get; set; }
            public string cocNumber { get; set; }
            public string vatNumber { get; set; }
            public string image { get; set; }
            public string contactData { get; set; }
        }

        public class Postaladdress
        {
            public string street { get; set; }
            public string houseNumber { get; set; }
            public string zipCode { get; set; }
            public string city { get; set; }
            public string countryCode { get; set; }
            public string countryName { get; set; }
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
}