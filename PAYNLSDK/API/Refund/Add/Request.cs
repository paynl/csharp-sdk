using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Refund.Add
{
    /// <summary>
    /// 
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="bankAccountHolder"></param>
        /// <param name="bankAccountNumber"></param>
        public Request(int amount, string bankAccountHolder, string bankAccountNumber, string BankAccountBic)
        {
            this.Amount = amount;
            this.BankAccountHolder = bankAccountHolder;
            this.BankAccountNumber = bankAccountNumber;
            this.BankAccountBic = BankAccountBic;

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

/* overrides */
        /// <summary>
        /// 
        /// </summary>
        public override int Version
        {
            get { return 7; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Controller
        {
            get { return "Refund"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Method
        {
            get { return "add"; }
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
        public override bool RequiresApiToken
        {
            get
            {


                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresServiceId
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = base.GetParameters();

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

            if (this.ProcessDate.HasValue)
            {
                nvc.Add("processDate", this.ProcessDate.Value.ToString("yyyy-MM-dd"));
            }

            return nvc;
        }

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
            if (!Response.Request.Result)
            {
                // toss
                throw new ErrorException(Response.Request.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Response Response { get { return (Response)response; } }
    }
}
