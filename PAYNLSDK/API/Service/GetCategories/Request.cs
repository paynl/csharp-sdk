using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.Service.GetCategories
{
    public class Request : RequestBase
    {
        [JsonProperty("paymentOptionId")]
        public int? PaymentOptionId { get; set; }

        public override int Version
        {
            get { return 3; }
        }

        public override string Controller
        {
            get { return "Service"; }
        }

        public override string Method
        {
            get { return "getCategories"; }
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

            if (!ParameterValidator.IsNonEmptyInt(PaymentOptionId))
            {
                nvc.Add("paymentOptionId", PaymentOptionId.ToString());
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
            PAYNLSDK.Objects.ServiceCategory[] pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.ServiceCategory[]>(RawResponse);
            Response r = new Response();
            r.ServiceCategories = pm;
            response = r;
        }
    }
}
