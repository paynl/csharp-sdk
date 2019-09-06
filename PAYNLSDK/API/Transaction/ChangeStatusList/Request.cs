using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;


namespace PAYNLSDK.API.Transaction.ChangeStatusList
{
    /// <summary>
    /// function to return all transactions after a certain timestamp
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

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
            get { return "changeStatusList"; }
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

            ParameterValidator.IsNotNull(Timestamp, "TimeStamp");
            nvc.Add("timestamp", Timestamp.ToString());

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

