using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.Approve
{
    /// <summary>
    /// function to approve a suspicious transaction
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }


        /// <summary>
        /// Entrance-code of transaction
        /// </summary>
        [JsonProperty("entranceCode")]
        public string EntranceCode { get; set; }

        /// <inheritdoc />
        protected override int Version => 16;

        /// <inheritdoc />
        protected override string Controller => "Transaction";

        /// <inheritdoc />
        protected override string Method => "approve";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
            nvc.Add("orderId", TransactionId);

            if (string.IsNullOrWhiteSpace(EntranceCode) == false)
            {
                nvc.Add("entranceCode", EntranceCode);
            }

            return nvc;

        }

        /// <inheritdoc cref="ResponseBase"/>
        public Response Response => (Response)response;

        /// <summary>
        /// 
        /// </summary>
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
