using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Validate.BankAccountNumber
{
    /// <summary>
    /// The request object to validate a bank account number
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// The bank account number
        /// </summary>
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        /// <inheritdoc />
        public override bool RequiresApiToken => false;

        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "Validate";

        /// <inheritdoc />
        protected override string Method => "BankAccountNumber";

        /// <inheritdoc />
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(BankAccountNumber, "bankAccountNumber");
            nvc.Add("bankAccountNumber", BankAccountNumber);

            return nvc;
        }

        /// <summary>
        /// the response from the request
        /// </summary>
        public Response Response => (Response)response;

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}
