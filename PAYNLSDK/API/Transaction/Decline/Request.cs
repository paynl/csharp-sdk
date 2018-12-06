using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.Decline
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
        /// not implemented
        /// </summary>
        //  [JsonProperty("entranceCode")]
        //   public string EntranceCode { get; set; }

        /* overrides */
        /// <inheritdoc />
        protected override int Version => 7;

        /// <inheritdoc />
        protected override string Controller => "Transaction";

        /// <inheritdoc />
        protected override string Method => "decline";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
            nvc.Add("orderId", TransactionId);

            // if (!ParameterValidator.IsEmpty(EntranceCode))
            // {
            //     nvc.Add("entranceCode", EntranceCode);
            // }

            return nvc;
        }

        /// <summary>
        /// 
        /// </summary>
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

