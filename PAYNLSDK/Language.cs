using PAYNLSDK.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYNLSDK.API.Alliance;
using PAYNLSDK.API.Alliance.GetMerchant;
using PAYNLSDK.API.Language;

namespace PAYNLSDK
{
    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    public class Language : ILanguage
    {
        private readonly IClient _webClient;

        /// <inheritdoc />
        public Language()
        {
            _webClient = new Client("", "");
        }

        /// <inheritdoc />
        public Language(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <inheritdoc />
        public GetMerchantResult GetAll()
        {
            var response = _webClient.PerformRequest(new GetAllRequest());
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetMerchantResult>(response);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ILanguage
    {
        GetMerchantResult GetAll();
    }
}