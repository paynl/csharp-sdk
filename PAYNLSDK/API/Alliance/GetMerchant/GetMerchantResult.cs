using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Alliance.GetMerchant
{
    /// <summary>
    /// The result of the Alliance/GetMerchant call
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
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
        [JsonProperty("bankaccounts")] public Bankaccount[] bankaccounts { get; set; }
        [JsonProperty("public_info")] public PublicInfo public_info { get; set; }
        [JsonProperty("contract")] public Contract contract { get; set; }

        public class Request
        {
            [JsonProperty("result")] public string result { get; set; }
            [JsonProperty("errorId")] public string errorId { get; set; }
            [JsonProperty("errorMessage")] public string errorMessage { get; set; }
        }

        public class PublicInfo
        {
            public string merchantId { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string typeName { get; set; }
            public PostalAddress postalAddress { get; set; }
            public string cocNumber { get; set; }
            public string vatNumber { get; set; }
            public string image { get; set; }
            public string contactData { get; set; }
        }

        public class PostalAddress
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
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("type_id")]
            public string type_id { get; set; }
            [JsonProperty("type_name")]
            public string type_name { get; set; }
            [JsonProperty("status_id")]
            public string status_id { get; set; }
            [JsonProperty("status_name")]
            public string status_name { get; set; }
            [JsonProperty("expires")]
            public string expires { get; set; }
        }

        public class Account
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("account_id")]
            public string account_id { get; set; }
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("accepted")]
            public string accepted { get; set; }
            [JsonProperty("access")]
            public string access { get; set; }
            [JsonProperty("ubo")]
            public string ubo { get; set; }
            [JsonProperty("authorised_to_sign")]
            public string authorised_to_sign { get; set; }
            [JsonProperty("signature_label")]
            public string signature_label { get; set; }
            [JsonProperty("documents")]
            public Document[] documents { get; set; }
        }

        public class Bankaccount
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("bankaccountHolder")]
            public string bankaccountHolder { get; set; }
            [JsonProperty("bankaccountNumber")]
            public string bankaccountNumber { get; set; }
            [JsonProperty("bic")]
            public string bic { get; set; }
            [JsonProperty("countryCode")]
            public string countryCode { get; set; }
        }

    }
}

