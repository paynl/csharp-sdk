namespace PAYNLSDK
{
    /// <summary>
    /// Alliance methods
    /// </summary>
    public interface IAlliance
    {
        /// <summary>
        /// This function can be used to retrieve alliance merchant information. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        API.Alliance.GetMerchant.GetMerchantResult GetMerchant(API.Alliance.GetMerchant.Request request);

        /// <summary>
        /// Adds the merchant.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>AddMerchantResult.</returns>
        API.Alliance.AddMerchant.AddMerchantResult AddMerchant(API.Alliance.AddMerchant.Request request);

        /// <summary>
        /// Adds a service for a merchant
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>AddServiceResult.</returns>
        API.Alliance.AddService.AddServiceResult AddService(API.Alliance.AddService.Request request);
        
        /// <summary>
        /// Inserts a transaction to collect an invoice fee. 
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>API.Alliance.AddInvoice.AddInvoiceResult.</returns>
        API.Alliance.AddInvoice.AddInvoiceResult AddInvoice(API.Alliance.AddInvoice.Request request);
    }
}
