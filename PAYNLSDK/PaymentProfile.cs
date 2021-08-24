using PAYNLSDK.Net;
using PaymentProfileGet = PAYNLSDK.API.PaymentProfile.Get.Request;
using PaymentProfileGetAll = PAYNLSDK.API.PaymentProfile.GetAll.Request;
using PaymentProfileGetAvailable = PAYNLSDK.API.PaymentProfile.GetAvailable.Request;

namespace PAYNLSDK
{
    /// <summary>
    /// Provides retrieval for payment options 
    /// </summary>
    public class PaymentProfile
    {
        private readonly IClient _webClient;
        
        /// <summary>
        /// Create a new payment profile Sdk
        /// </summary>
        /// <param name="webClient"></param>
        public PaymentProfile(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <summary>
        /// Get details for a specific payment profile
        /// </summary>
        /// <param name="paymentProfileId">Payment profile ID</param>
        /// <returns>Payment profile response</returns>
        public PAYNLSDK.API.PaymentProfile.Get.Response Get(int paymentProfileId)
        {
            var request = new PaymentProfileGet
            {
                PaymentProfileId = paymentProfileId
            };

            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <summary>
        /// Get details for all payment profiles
        /// </summary>
        /// <returns>List of payment profile info</returns>
        public PAYNLSDK.API.PaymentProfile.GetAll.Response GetAll()
        {
            PaymentProfileGetAll request = new PaymentProfileGetAll();
            
            _webClient.PerformRequest(request);
            return request.Response;
        }

        /// <summary>
        /// Get payment profile information for all your available profiles for the specified service category
        /// </summary>
        /// <param name="categoryId">The ID of the category of the service the payment options are used for</param>
        /// <param name="programId">ID of the program for which the payment options are used. (Only available if the program option is enabled!)</param>
        /// <param name="paymentMethodId">Payment Method ID</param>
        /// <param name="showNotAllowedOnRegistration">Indicator wether to show profiles that are initially not allowed on registration. </param>
        /// <returns>Response containing the list of payment profile information</returns>
        public PAYNLSDK.API.PaymentProfile.GetAvailable.Response GetAvailable(int categoryId, int? programId = null, int? paymentMethodId = null, bool? showNotAllowedOnRegistration = null)
        {
            var request = new PaymentProfileGetAvailable
            {
                CategoryId = categoryId,
                ProgramId = programId,
                PaymentMethodId = paymentMethodId,
                ShowNotAllowedOnRegistration = showNotAllowedOnRegistration
            };

            _webClient.PerformRequest(request);
            return request.Response;
        }

    }
}
