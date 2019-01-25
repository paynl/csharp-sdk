using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace PAYNLSDK.API.Alliance.AddInvoice
{
    /// <inheritdoc />
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
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
            var retval = new NameValueCollection
            {

                // mandatory fields
                { "serviceId", ServiceId },
                { "merchantId", MerchantId },
                { "invoiceId", InvoiceId },
                { "amount", AmountInCents.ToString() },
                { "description", Description }
            };

            // Optional fields
            if (string.IsNullOrWhiteSpace(InvoiceUrl) == false)
            {
                retval.Add("invoiceUrl", InvoiceUrl);
            }

            if (MakeYesterday.HasValue)
            {
                retval.Add("makeYesterday", MakeYesterday.ToString().ToLower());
            }

            if (string.IsNullOrWhiteSpace(Extra1) == false)
            {
                retval.Add("extra1", Extra1);
            }

            if (string.IsNullOrWhiteSpace(Extra2) == false)
            {
                retval.Add("extra2", Extra2);
            }

            if (string.IsNullOrWhiteSpace(Extra3) == false)
            {
                retval.Add("extra2", Extra3);
            }

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
        /// <value><c>true</c> transactions should be booked yesterday; otherwise, <c>false</c>.</value>
        public bool? MakeYesterday { get; set; }

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

        /// <inheritdoc />
        /// <exception cref="T:PAYNLSDK.Exceptions.PayNlException">rawResponse is empty!</exception>
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
        }
    }

}
