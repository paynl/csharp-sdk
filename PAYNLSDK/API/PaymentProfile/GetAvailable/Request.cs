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
        /// <summary>
        /// The ID of the category of the service the payment options are used for. 
        /// For a list of available categories, see <see cref="PAYNLSDK.API.Service.GetCategories"/>
        /// </summary>
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        /// <summary>
        /// ID of the program for which the payment options are used. (Only available if the program option is enabled!)
        /// </summary>
        [JsonProperty("programId")]
        public int? ProgramId { get; set; }

        /// <summary>
        /// Optional ID of the payment method
        /// </summary>
        [JsonProperty("paymentMethodId")]
        public int? PaymentMethodId { get; set; }

        /// <summary>
        /// Indicator wether to show profiles that are initially not allowed on registration. 
        /// </summary>
        [JsonProperty("showNotAllowedOnRegistration"), JsonConverter(typeof(BooleanConverter))]
        public bool? ShowNotAllowedOnRegistration { get; set; }

        public override int Version => 1;

        public override string Controller => "PaymentProfile";

        public override string Method => "getAvailable";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

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
                nvc.Add("ShowNotAllowedOnRegistration", ((bool)ShowNotAllowedOnRegistration) ? "1" : "0");
            }

            return nvc;
        }

        public Response Response { get { return (Response)response; } }

        protected override void PrepareAndSetResponse()
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
