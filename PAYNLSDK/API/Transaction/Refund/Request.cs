using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.Refund
{
    public class Request : RequestBase
    {
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("processDate"),JsonConverter(typeof(DMYConverter))]
        public DateTime? ProcessDate { get; set; }

        public override int Version
        {
            get { return 7; }
        }

        public override string Controller
        {
            get { return "Transaction"; }
        }

        public override string Method
        {
            get { return "refund"; }
        }
        
        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
            nvc.Add("transactionId", TransactionId);

            if (!ParameterValidator.IsNull(Amount))
            {
                nvc.Add("amount", Amount.ToString());
            }

            if (!ParameterValidator.IsEmpty(Description))
            {
                nvc.Add("description", Description);
            }

            if (!ParameterValidator.IsNull(ProcessDate))
            {
                nvc.Add("processDate", ((DateTime)ProcessDate).ToString("yyyy-MM-dd"));
            }

            return nvc;
        }
        public Response Response { get { return (Response)response; } }

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
