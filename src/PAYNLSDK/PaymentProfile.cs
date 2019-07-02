using System.Threading.Tasks;
using PAYNLSDK.Base;
using PAYNLSDK.Services;
using PaymentProfileGet = PAYNLSDK.API.PaymentProfile.Get.Request;
using PaymentProfileGetAll = PAYNLSDK.API.PaymentProfile.GetAll.Request;
using PaymentProfileGetAvailable = PAYNLSDK.API.PaymentProfile.GetAvailable.Request;

namespace PAYNLSDK
{
    /// <summary>
    /// Generic Payment Profile service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class PaymentProfile : BaseClient
    {
        public PaymentProfile(IClientService clientService)
            : base(clientService)
        {
        }

        /// <summary>
        /// Get details for a specific payment profile
        /// </summary>
        /// <param name="paymentProfileId">Payment profile ID</param>
        /// <returns>Payment profile response</returns>
        public async Task<API.PaymentProfile.Get.Response> GetAsync(int paymentProfileId)
        {
            var request = new PaymentProfileGet
            {
                PaymentProfileId = paymentProfileId
            };

            await ClientService.PerformPostRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// Get details for all payment profiles
        /// </summary>
        /// <returns>List of payment profile info</returns>
        public async Task<API.PaymentProfile.GetAll.Response> GetAllAsync()
        {
            var request = new PaymentProfileGetAll();
            await ClientService.PerformPostRequestAsync(request);
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
        public async Task<API.PaymentProfile.GetAvailable.Response> GetAvailableAsync(int categoryId, int? programId, int? paymentMethodId, bool? showNotAllowedOnRegistration)
        {
            var request = new PaymentProfileGetAvailable
            {
                CategoryId = categoryId,
                ProgramId = programId,
                PaymentMethodId = paymentMethodId,
                ShowNotAllowedOnRegistration = showNotAllowedOnRegistration
            };

            await ClientService.PerformPostRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// Get payment profile information for all your available profiles for the specified service category
        /// </summary>
        /// <param name="categoryId">The ID of the category of the service the payment options are used for</param>
        /// <param name="programId">ID of the program for which the payment options are used. (Only available if the program option is enabled!)</param>
        /// <param name="paymentMethodId">Payment Method ID</param>
        /// <returns>Response containing the list of payment profile information</returns>
        public Task<API.PaymentProfile.GetAvailable.Response> GetAvailableAsync(int categoryId, int? programId, int? paymentMethodId) =>
            GetAvailableAsync(categoryId, programId, paymentMethodId, null);

        /// <summary>
        /// Get payment profile information for all your available profiles for the specified service category
        /// </summary>
        /// <param name="categoryId">The ID of the category of the service the payment options are used for</param>
        /// <param name="programId">ID of the program for which the payment options are used. (Only available if the program option is enabled!)</param>
        /// <returns>Response containing the list of payment profile information</returns>
        public Task<API.PaymentProfile.GetAvailable.Response> GetAvailableAsync(int categoryId, int? programId) =>
            GetAvailableAsync(categoryId, programId, null, null);

        /// <summary>
        /// Get payment profile information for all your available profiles for the specified service category
        /// </summary>
        /// <param name="categoryId">The ID of the category of the service the payment options are used for</param>
        /// <returns>Response containing the list of payment profile information</returns>
        public Task<API.PaymentProfile.GetAvailable.Response> GetAvailableAsync(int categoryId) =>
            GetAvailableAsync(categoryId, null, null, null);
    }
}
