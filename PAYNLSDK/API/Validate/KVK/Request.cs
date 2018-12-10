using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace PAYNLSDK.API.Validate.KVK
{
    /// <summary>
    /// Request to validate the KVK number
    /// Implements the <see cref="PAYNLSDK.API.RequestBase" />
    /// </summary>
    /// <inheritdoc />
    /// <seealso cref="PAYNLSDK.API.RequestBase" />
    public class Request : RequestBase
    {
        /// <summary>
        /// Gets or sets the "kamer van koophandel" number.
        /// </summary>
        /// <value>The KVK.</value>
        [JsonProperty("kvk")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public string KVK { get; set; }

        /// <inheritdoc />
        public override bool RequiresApiToken => false;// base.RequiresApiToken;

        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "Validate";

        /// <inheritdoc />
        protected override string Method => "KVK";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(KVK, "kvk");
            nvc.Add("kvk", KVK);

            return nvc;
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
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
