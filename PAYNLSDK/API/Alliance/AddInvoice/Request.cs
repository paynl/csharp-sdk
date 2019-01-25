using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;

namespace PayNLSdk.API.Alliance.AddInvoice
{
    /// <inheritdoc />
    public class Request : RequestBase
    {
        /// <inheritdoc />
        protected override int Version => 5;
        /// <inheritdoc />
        protected override string Controller => "Alliance";
        /// <inheritdoc />
        protected override string Method => "addInvoice";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var retval = new NameValueCollection { };

            // mandatory fields
            retval.Add("serviceId", ServiceId);
            retval.Add("merchantId", MerchantId);
            retval.Add("invoiceId", InvoiceId);
            retval.Add("amount", AmountInCents.ToString());
            retval.Add("description", Description);

            retval.Add("invoiceUrl", InvoiceUrl);
            retval.Add("makeYesterday", MakeYesterday.ToString().ToLower());
            retval.Add("extra1", Extra1);
            retval.Add("extra2", Extra2);
            retval.Add("extra2", Extra3);

            return retval;
        }

        /// <summary>
        /// Gets or sets the third free value.
        /// </summary>
        /// <value>The extra3.</value>
        public string Extra3 { get; set; }

        /// <summary>
        /// Gets or sets the second free value.
        /// </summary>
        /// <value>The extra2.</value>
        public string Extra2 { get; set; }

        /// <summary>
        /// Gets or sets the first free value.
        /// </summary>
        /// <value>The extra1.</value>
        public string Extra1 { get; set; }

        /// <summary>
        /// Gets or sets the id of your invoice.
        /// </summary>
        /// <value>The invoice identifier.</value>
        public string InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets whether the transaction should be backdated to yesterday 23:59:59
        /// </summary>
        /// <value><c>true</c> if [make yester day]; otherwise, <c>false</c>.</value>
        public bool MakeYesterday { get; set; }

        /// <summary>
        /// Gets or sets the URL pointing to the location of the invoice.
        /// </summary>
        /// <value>The invoice URL.</value>
        public string InvoiceUrl { get; set; }

        /// <summary>
        /// Gets or sets payment description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the amount in cents.
        /// </summary>
        /// <value>The amount in cents.</value>
        public long AmountInCents { get; set; }

        /// <summary>
        /// Gets or sets the merchantId of the merchant to invoice.
        /// </summary>
        /// <value>The merchant identifier.</value>
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets the serviceId of the service the payment should be registered on.
        /// </summary>
        /// <value>The service identifier.</value>
        public string ServiceId { get; set; }

        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
        }
    }

}
