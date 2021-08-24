using System.Diagnostics.CodeAnalysis;
using PAYNLSDK.Net;

namespace PAYNLSDK
{
    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Alliance : IAlliance
    {
        private readonly IClient _webClient;

        /// <summary>
        /// Create a new API client for the Alliance API
        /// </summary>
        /// <param name="webClient"></param>
        public Alliance(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <inheritdoc />
        public PAYNLSDK.API.Alliance.GetMerchant.GetMerchantResult GetMerchant(API.Alliance.GetMerchant.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PAYNLSDK.API.Alliance.GetMerchant.GetMerchantResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.AddMerchant.AddMerchantResult AddMerchant(API.Alliance.AddMerchant.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.AddMerchant.AddMerchantResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.AddService.AddServiceResult AddService(API.Alliance.AddService.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.AddService.AddServiceResult>(response);
        }

        /// <inheritdoc />
        public API.Alliance.AddInvoice.AddInvoiceResult AddInvoice(API.Alliance.AddInvoice.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<API.Alliance.AddInvoice.AddInvoiceResult>(response);
        }
    }
}
