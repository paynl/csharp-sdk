using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Transaction.Refund
{
    /// <summary>
    /// The request object to be send
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// The order ID or EX code of the transaction.
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Amount to be paid in cents. 
        /// For example € 3.50 becomes 350. 
        /// </summary>
        [JsonProperty("amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// description to include with the payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The date on which the refund needs to be processed. Only works for IBAN refunds.
        /// </summary>
        /// <remarks>Internal format should be , format dd-mm-yyyy(eg. 25-09-2016)</remarks>
        [JsonProperty("processDate"), JsonConverter(typeof(DMYConverter))]
        public DateTime? ProcessDate { get; set; }

        /// <inheritdoc />
        protected override int Version => 11;

        /// <inheritdoc />
        protected override string Controller => "Transaction";

        /// <inheritdoc />
        protected override string Method => "refund";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();

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
                nvc.Add("processDate", ((DateTime)ProcessDate).ToString("dd-MM-yyyy"));
            }

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
