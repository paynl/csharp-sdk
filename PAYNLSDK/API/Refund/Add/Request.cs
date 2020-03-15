using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Refund.Add
{
    /// <summary>
    /// 
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// A refund is the repayment of (part of) a transaction to the end user.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="bankAccountHolder"></param>
        /// <param name="bankAccountNumber"></param>
        /// <param name="bankAccountBic"></param>
        public Request(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            Amount = amount;
            BankAccountHolder = bankAccountHolder;
            BankAccountNumber = bankAccountNumber;
            BankAccountBic = bankAccountBic;
        }

        /// <summary>
        /// The amount to be paid should be given in cents. For example € 3.50 becomes 350.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string BankAccountHolder { get; set; }

        /// <summary>
        /// The bankaccount number of the customer.
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// The BIC of the bank.
        /// </summary>
        public string BankAccountBic { get; set; }

        /// <summary>
        /// The description to include with the payment.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The id of a promotor / affiliate.
        /// In general, you won't use this unless you know the ID's of your affiliate's
        /// </summary>
        public int? PromotorId { get; set; }

        /// <summary>
        /// The used tool code.
        /// </summary>
        public string Tool { get; set; }

        /// <summary>
        /// The used info code which can be tracked in the stats
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// The used object.
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// The first free value which can be tracked in the stats
        /// </summary>
        public string Extra1 { get; set; }

        /// <summary>
        /// The second free value which can be tracked in the stats
        /// </summary>
        public string Extra2 { get; set; }

        /// <summary>
        /// The third free value which can be tracked in the stats
        /// </summary>
        public string Extra3 { get; set; }

        /// <summary>
        /// id from the payment
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// The currency of the amount, default is EUR.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The currency of the amount, default is EUR.
        /// </summary>
        public DateTime? ProcessDate { get; set; }

        /// <inheritdoc />
        protected override int Version => 7;

        /// <inheritdoc />
        protected override string Controller => "Refund";

        /// <inheritdoc />
        protected override string Method => "add";

        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresApiToken => true;
        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresServiceId => true;

        /// <inheritdoc />
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotNull(Amount, "Amount");
            nvc.Add("amount", Amount.ToString());

            ParameterValidator.IsNotNull(BankAccountHolder, "BankAccountHolder");
            nvc.Add("bankAccountHolder", BankAccountHolder);

            ParameterValidator.IsNotNull(BankAccountNumber, "BankAccountNumber");
            nvc.Add("bankAccountNumber", BankAccountNumber);

            ParameterValidator.IsNotNull(BankAccountBic, "BankAccountBic");
            nvc.Add("bankAccountBic", BankAccountBic);

            if (!ParameterValidator.IsEmpty(Description))
            {
                nvc.Add("description", Description);
            }

            if (!ParameterValidator.IsNonEmptyInt(PromotorId))
            {
                nvc.Add("promotorId", PromotorId.Value.ToString());
            }

            if (!ParameterValidator.IsEmpty(Tool))
            {
                nvc.Add("tool", Tool);
            }

            if (!ParameterValidator.IsEmpty(Info))
            {
                nvc.Add("info", Info);
            }

            if (!ParameterValidator.IsEmpty(Object))
            {
                nvc.Add("object", Object);
            }

            if (!ParameterValidator.IsEmpty(Extra1))
            {
                nvc.Add("extra1", Extra1);
            }
            if (!ParameterValidator.IsEmpty(Extra2))
            {
                nvc.Add("extra2", Extra2);
            }
            if (!ParameterValidator.IsEmpty(Extra3))
            {
                nvc.Add("extra3", Extra3);
            }

            if (!ParameterValidator.IsEmpty(Currency))
            {
                nvc.Add("currency", Currency);
            }

            if (!ParameterValidator.IsEmpty(OrderId))
            {
                nvc.Add("orderId", OrderId);
            }

            if (ProcessDate.HasValue)
            {
                nvc.Add("processDate", ProcessDate.Value.ToString("yyyy-MM-dd"));
            }

            return nvc;
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
            if (!Response.Request.Result)
            {
                // toss
                throw new PayNlException(Response.Request.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Response Response => (Response)response;
    }
}
