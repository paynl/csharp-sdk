using System.Threading.Tasks;
using PAYNLSDK.Base;
using PAYNLSDK.Services;
using PaymentMethodGet = PAYNLSDK.API.PaymentMethod.Get.Request;
using PaymentMethodGetAll = PAYNLSDK.API.PaymentMethod.GetAll.Request;

namespace PAYNLSDK
{
    /// <summary>
    /// Generic Payment Method service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class PaymentMethod : BaseClient
    {
        public PaymentMethod(IClientService clientService)
            : base(clientService)
        {
        }

        /// <summary>
        /// Get information for the requested payment method.
        /// </summary>
        /// <param name="paymentMethodId">Payment Method ID</param>
        /// <returns>Response containing the payment method data</returns>
        public async Task<API.PaymentMethod.Get.Response> GetAsync(int paymentMethodId)
        {
            var request = new PaymentMethodGet
            {
                PaymentMethodId = paymentMethodId
            };

            await ClientService.PerformPostRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// Get information for all payment methods.
        /// </summary>
        /// <returns>Response containing a list of information for all payment methods</returns>
        public async Task<API.PaymentMethod.GetAll.Response> GetAllAsync()
        {
            var request = new PaymentMethodGetAll();
            await ClientService.PerformPostRequestAsync(request);
            return request.Response;
        }
    }
}
