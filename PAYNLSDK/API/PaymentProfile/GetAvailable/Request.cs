using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.PaymentProfile.GetAvailable
{
    public class Request : RequestBase
    {
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("programId")]
        public int? ProgramId { get; set; }

        [JsonProperty("paymentMethodId")]
        public int? PaymentMethodId { get; set; }

        [JsonProperty("showNotAllowedOnRegistration"),JsonConverter(typeof(BooleanConverter))]
        public bool? ShowNotAllowedOnRegistration { get; set; }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "PaymentProfile"; }
        }

        public override string Method
        {
            get { return "getAvailable"; }
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

            ParameterValidator.IsNotNull(CategoryId, "CategoryId");
            nvc.Add("categoryId", CategoryId.ToString());

            if (!ParameterValidator.IsNonEmptyInt(ProgramId))
            {
                nvc.Add("programId", ProgramId.ToString());
            }

            if (!ParameterValidator.IsNonEmptyInt(PaymentMethodId))
            {
                nvc.Add("paymentMethodId", PaymentMethodId.ToString());
            }

            if (!ParameterValidator.IsNull(ShowNotAllowedOnRegistration))
            {
                nvc.Add("ShowNotAllowedOnRegistration", ((bool)ShowNotAllowedOnRegistration) ? "1" : "0" );
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
            PAYNLSDK.Objects.PaymentProfile[] pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.PaymentProfile[]>(RawResponse);
            Response r = new Response();
            r.PaymentProfiles = pm;
            response = r;
        }
    }
}
