using PAYNLSDK.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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

        public object GetMerchant(API.Alliance.GetMerchant.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return API.Merchant.Add.Response.FromRawResponse(response);
        }

    }

    public interface IAlliance
    {
        object GetMerchant(API.Alliance.GetMerchant.Request request);
    }
}