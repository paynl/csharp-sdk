using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
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
        /// not implemented
        /// </summary>
        //  [JsonProperty("entranceCode")]
        //   public string EntranceCode { get; set; }

        /// <inheritdoc />
        protected override int Version
        {
            get { return 7; }
        }

        /// <inheritdoc />
        protected override string Controller
        {
            get { return "Transaction"; }
        }

        /// <inheritdoc />
        protected override string Method
        {
            get { return "approve"; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

                ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
                nvc.Add("orderId", TransactionId);

                return nvc;
       
        }

        /// <summary>
        /// 
        /// </summary>
        public Response Response { get { return (Response)response; } }

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
