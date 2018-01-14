using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.Info
{
    public class Request : RequestBase
    {
        /// <summary>
        /// Mandatory transaction identifier
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required]
        public string TransactionId { get; set; }

        /// <summary>
        /// Unique code related to the order.
        /// </summary>
        public string EntranceCode { get; set; }

        /// <inheritdoc />
        public override int Version => 5;

        /// <inheritdoc />
        public override string Controller => "Transaction";

        /// <inheritdoc />
        public override string Method => "info";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();
            
            ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
            nvc.Add("transactionId", TransactionId);

            if (!ParameterValidator.IsEmpty(EntranceCode))
            {
                nvc.Add("entranceCode", EntranceCode);
            }
            return nvc;
        }
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
