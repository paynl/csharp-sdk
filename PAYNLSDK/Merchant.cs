using PAYNLSDK.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK
{
    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    public class Merchant : IMerchant
    {
        private readonly IClient _webClient;

        /// <summary>
        /// The merchant api. This is a part from the alliance SDK.
        /// </summary>
        /// <param name="webClient"></param>
        public Merchant(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <summary>Create a new merchant</summary>
        /// <remarks></remarks>
        /// <returns>A new <see cref="API.Merchant.Add.Response"/> object</returns>
        public API.Merchant.Add.Response Create(API.Merchant.Add.Request request)
        {
            var response = _webClient.PerformRequest(request);
            return API.Merchant.Add.Response.FromRawResponse(response);
        }

        /// <summary>
        /// Get a specific merchant by id
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public API.Merchant.Get.Response Get(string merchantId)
        {
            //api = new Api\GetMerchant();
            //   if (!String.IsNullOrEmpty( options['merchantId']))
            //   {
            //    api->setMerchantId( options['merchantId']);
            //   }

            //result =  api->doRequest();

            var request = new API.Merchant.Get.Request
            {
                MerchantId = merchantId
            };

            var response = _webClient.PerformRequest(request);
            return API.Merchant.Get.Response.FromRawResponse(response);
        }

        /// <summary>
        /// Get a list of all merchants
        /// </summary>
        public object GetAll( /*options = array()*/)
        {
            throw new NotImplementedException("this is not yet implemented");
            //api = new Api\GetMerchants();

            //   if (!String.IsNullOrEmpty( options['state']))
            //   {
            //    api->setState( options['state']);
            //   }


            //var request = new API.Merchant.GetAll.Request
            //{
            //    MerchantId = "TODO"
            //};

            //var response = _webClient.PerformRequest(request);
            //return API.Merchant.GetAll.Response.FromRawResponse(response);

            return new object(); // Result\Merchant\GetList( result);
        }

        public enum MerchantState
        {
            NewMerchant,

        }
    }
}
