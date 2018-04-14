using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Merchant.Get
{
    public class Request : RequestBase
    {
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        public override int Version { get; }
        public override string Controller => "Merchant";
        public override string Method => "info";

        public override NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();
            nvc.Add("merchantId", MerchantId);

            return nvc;
        }

        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<API.Merchant.Get.Response>(RawResponse);
            if (!response.Request.Result)
            {
                // toss
                throw new PayNlException(response.Request.Message);
            }
        }
    }
}
