using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;
using System.Globalization;

namespace PAYNLSDK.API.Transaction.Refund
{
    /// <summary>
    /// A normal refund from a previously placed transaction.
    /// If you are doing a refund from Sofort or AfterPay, you'll need to use <seealso cref="PAYNLSDK.API.Refund.Transaction.Request"/>
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
        /// If no amount is specified, the full amount is refunded and currency is not used. 
        /// </summary>
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// description to include with the payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The date on which the refund needs to be processed. Only works for IBAN refunds.
        /// </summary>
        /// <remarks>Internal format should be dd-mm-yyyy(eg. 25-09-2016)</remarks>
        [JsonProperty("processDate"), JsonConverter(typeof(DMYConverter))]
        public DateTime? ProcessDate { get; set; }

        /// <inheritdoc />
        protected override int Version => 16;

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

            if (Amount.HasValue)
            {
                nvc.Add("amount", ((int)Math.Floor(Amount.Value * 100)).ToString());
            }

            if (!ParameterValidator.IsEmpty(Description))
            {
                nvc.Add("description", Description);
            }

            if (ProcessDate.HasValue)
            {
                nvc.Add("processDate", ProcessDate.Value.ToString("dd-MM-yyyy"));
            }

            if (VatPercentage.HasValue)
            {
                nvc.Add("vatPercentage", VatPercentage.Value.ToString(CultureInfo.InvariantCulture));
            }

            return nvc;
        }

        /// <summary>
        /// the vat percentage this refund applies to (AfterPay/Focum only)
        /// </summary>
        [JsonProperty("vatPercentage")]
        public decimal? VatPercentage { get; set; }

        /// <summary>
        /// Optional field. The currency in which the amount is specified. Standard in euro.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

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
