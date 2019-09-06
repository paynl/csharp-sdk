using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.Details
{
    /// <summary>
    /// function to get all transaction details
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Entrance Code
        /// </summary>
        [JsonProperty("entranceCode")]
        public string EntranceCode { get; set; }

        /* overrides */
        /// <summary>
        /// 
        /// </summary>
        public override int Version
        {
            get { return 14; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Controller
        {
            get { return "Transaction"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Method
        {
            get { return "details"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Querystring
        {
            get { return ""; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = base.GetParameters();

            ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
            nvc.Add("transactionId", TransactionId);

            if (!ParameterValidator.IsEmpty(EntranceCode))
            {
                nvc.Add("entranceCode", EntranceCode);
            }

            return nvc;
        }

        /// <summary>
        /// 
        /// </summary>
        public Response Response { get { return (Response)response; } }

        /// <summary>
        /// 
        /// </summary>
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

