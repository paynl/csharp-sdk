using Newtonsoft.Json;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Banktransfer.Add
{
    /// <summary>
    /// A new ADD request for the banktransfer (payment option id 136)
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// Create a new bank transfer request object
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="bankAccountHolder"></param>
        /// <param name="bankAccountNumber"></param>
        /// <param name="bankAccountBic"></param>
        public Request(decimal amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            AmountInCents = (int)Math.Floor(amount * 100);
            BankAccountHolder = bankAccountHolder;
            BankAccountNumber = bankAccountNumber;
            BankAccountBic = bankAccountBic;
        }

        /// <summary>
        /// The amount to be paid should be given in cents. For example € 3.50 becomes 350.
        /// </summary>
        public int AmountInCents { get; set; }

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
        /// The id of a promotor webmaster / affiliate.
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
        /// The currency of the amount, default is EUR.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The currency of the amount, default is EUR.
        /// </summary>
        public DateTime? ProcessDate { get; set; }

        /// <inheritdoc />
        protected override int Version => 1;

        /// <inheritdoc />
        protected override string Controller => "Banktransfer";

        /// <inheritdoc />
        protected override string Method => "add";

        /// <inheritdoc />
        public override bool RequiresApiToken => true;

        /// <inheritdoc />
        public override bool RequiresServiceId => true;

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var nvc = new NameValueCollection();

            ParameterValidator.IsNotNull(AmountInCents, "Amount");
            nvc.Add("amount", AmountInCents.ToString());

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

            if (PromotorId.HasValue)
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

            if (ProcessDate.HasValue)
            {
                nvc.Add("processDate", ProcessDate.Value.ToString("yyyy-MM-dd"));
            }

            return nvc;
        }

        /// <overridedoc />
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

        /// <overridedoc />
        public Response Response => (Response)response;
    }
}
