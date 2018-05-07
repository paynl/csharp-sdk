using PAYNLSDK.Net;
using PAYNLSDK.API.Alliance.AddMerchant;
using PAYNLSDK.API.Alliance.AddService;
using PAYNLSDK.API.Alliance.GetMerchant;


namespace PAYNLSDK
{
    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    public class Alliance : IAlliance
    {
        private readonly IClient _webClient;

        /// <inheritdoc />
        public Alliance(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <inheritdoc />
        public GetMerchantResult GetMerchant(API.Alliance.GetMerchant.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetMerchantResult>(response);
        }

        /// <inheritdoc />
        public AddMerchantResult AddMerchant(API.Alliance.AddMerchant.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddMerchantResult>(response);
        }

        /// <inheritdoc />
        public AddServiceResult AddService(API.Alliance.AddService.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddServiceResult>(response);
        }
    }

    /// <summary>
    /// Alliance methods
    /// </summary>
    public interface IAlliance
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetMerchantResult GetMerchant(API.Alliance.GetMerchant.Request request);

        /// <summary>
        /// Adds the merchant.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>AddMerchantResult.</returns>
        AddMerchantResult AddMerchant(API.Alliance.AddMerchant.Request request);

        /// <summary>
        /// Adds a service for a merchant
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>AddServiceResult.</returns>
        AddServiceResult AddService(API.Alliance.AddService.Request request);
    }
}