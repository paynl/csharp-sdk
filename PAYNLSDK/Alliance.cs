using PAYNLSDK.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PAYNLSDK.API.Alliance;
using PAYNLSDK.API.Alliance.AddMerchant;
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
        public Alliance()
        {
            _webClient = new Client("", "");
        }

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
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IAlliance
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetMerchantResult GetMerchant(API.Alliance.GetMerchant.Request request);
    }
}