using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Merchant.Add
{
    /// <summary>
    /// Reponse from the Merchant add command
    /// </summary>
    public class Response : ResponseBase
    {
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("merchantName")] public string MerchantName { get; set; }
        [JsonProperty("packageName")] public string PackageName { get; set; }
        [JsonProperty("invoiceAllowed")] public bool GetInvoiceAllowed { get; set; }
        [JsonProperty("payoutInterval")] public string PayoutInterval { get; set; }
        [JsonProperty("createdDate")] public string CreateDate { get; set; }
        [JsonProperty("acceptedDate")] public string AcceptedDate { get; set; }
        [JsonProperty("deletedDate")] public string DeletedDate { get; set; }
        [JsonProperty("services")] public string Services { get; set; }
    }
}
