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

        /// <inheritdoc />
        public Merchant()
        {
            _webClient = new Client("", "");
        }

        /// <inheritdoc />
        public Merchant(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <summary>Create a new merchant</summary>
        /// <remarks></remarks>
        /// <returns>A new <see cref="API.Merchant.Add.Response"/> object</returns>
        public API.Merchant.Add.Response Create(API.Merchant.Add.Request request)
        {
            // api = new Api\AddMerchant();

            //    if (!String.IsNullOrEmpty( options['accounts']))
            //    {
            //        self::_addAccounts( options['accounts'],  api);
            //    }
            // merchant = self::_getMerchant( options);
            // api->setMerchant( merchant);

            // bankAccount = self::_getBankAccount( options);
            //    if (!empty( bankAccount))
            //    {
            //     api->setBankAccount( bankAccount);
            //    }

            // settings = self::_getSettings( options);
            //    if (!empty( settings))
            //    {
            //     api->setSettings( settings);
            //    }

            // result =  api->doRequest();

            var response = _webClient.PerformRequest(request);
            return API.Merchant.Add.Response.FromRawResponse(response);
        }

        /**
         * @param  options
         * @return Result\Merchant\Get
         */
        public API.Merchant.Get.Response Get(string merchantId)
        {
            //api = new Api\GetMerchant();
            //   if (!String.IsNullOrEmpty( options['merchantId']))
            //   {
            //    api->setMerchantId( options['merchantId']);
            //   }

            //result =  api->doRequest();

            var request = new API.Merchant.Get.Request();
            request.MerchantId = merchantId;

            var response = _webClient.PerformRequest(request);
            return API.Merchant.Get.Response.FromRawResponse(response);
        }

        public object getList( /*options = array()*/)
        {
            throw new NotImplementedException("this is not yet implemented");
            //api = new Api\GetMerchants();

            //   if (!String.IsNullOrEmpty( options['state']))
            //   {
            //    api->setState( options['state']);
            //   }

            //result =  api->doRequest();

            return new object(); // Result\Merchant\GetList( result);
        }
    }
}