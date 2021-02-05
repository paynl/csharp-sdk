using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.GetService
{
    public class Request : RequestBase
    {
        public override bool RequiresServiceId
        {
            get
            {
                return true;
            }
        }

        [JsonProperty("paymentMethodId")]
        public PAYNLSDK.Enums.PaymentMethodId? PaymentMethodId { get; set; }

        public override int Version
        {
            get { return 16; }
        }

        public override string Controller
        {
            get { return "Transaction"; }
        }

        public override string Method
        {
            get { return "getService"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        private string apiToken;

        private string serviceId;

        public string GetApiToken()
        {
            return apiToken;
        }

        public void SetApiToken(string value)
        {
            apiToken = value;
        }

        public string GetServiceId()
        {
            return serviceId;
        }

        public void SetServiceId(string value)
        {
            serviceId = value;
        }

        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = base.GetParameters();

            if (RequiresApiToken)
            {
                if (!String.IsNullOrEmpty(GetApiToken()))
                {
                    nvc.Add("token", GetApiToken());
                }
            }

            if (RequiresServiceId)
            {
                if (!String.IsNullOrEmpty(GetServiceId()))
                {
                    nvc.Add("serviceId", GetServiceId());
                }
            }

            if (!ParameterValidator.IsNull(PaymentMethodId))
            {
                nvc.Add("paymentMethodId", ((int)PaymentMethodId).ToString());
            }
            return nvc;
        }
        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}
