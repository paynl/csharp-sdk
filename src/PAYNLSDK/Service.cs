using System.Threading.Tasks;
using PAYNLSDK.Base;
using PAYNLSDK.Services;
using ServiceGetCategories = PAYNLSDK.API.Service.GetCategories.Request;

namespace PAYNLSDK
{
    /// <summary>
    /// Generic Service service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class Service : BaseClient
    {
        public Service(IClientService clientService)
            : base(clientService)
        {
        }

        /// <summary>
        /// Get Service Categories for a given payment option ID
        /// </summary>
        /// <param name="paymentOptionId">Payment Option ID</param>
        /// <returns>Response object containing service categories</returns>
        public async Task<API.Service.GetCategories.Response> GetCategoriesAsync(int? paymentOptionId)
        {
            var request = new ServiceGetCategories
            {
                PaymentOptionId = paymentOptionId
            };

            await ClientService.PerformRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// Get Service Categories
        /// </summary>
        /// <returns>Response object containing service categories</returns>
        public Task<API.Service.GetCategories.Response> GetCategoriesAsync() =>
            GetCategoriesAsync(null);
    }
}
