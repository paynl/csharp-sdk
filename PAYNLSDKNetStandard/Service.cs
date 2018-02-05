using PAYNLSDK.Enums;
using PAYNLSDK.Net;
using System;
using ServiceGetCategories = PAYNLSDK.API.Service.GetCategories.Request;

namespace PAYNLSDK
{
    /// <summary>
    /// Generic Service service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Get Service Categories for a given payment option ID
        /// </summary>
        /// <param name="paymentOptionId">Payment Option ID</param>
        /// <returns>Response object containing service categories</returns>
        static public PAYNLSDK.API.Service.GetCategories.Response GetCategories(int? paymentOptionId)
        {
            ServiceGetCategories request = new ServiceGetCategories();
            request.PaymentOptionId = paymentOptionId;
            Client c = new Client("", "");
            c.PerformRequestAsync(request);
            return request.Response;
        }

        /// <summary>
        /// Get Service Categories
        /// </summary>
        /// <returns>Response object containing service categories</returns>
        static public PAYNLSDK.API.Service.GetCategories.Response GetCategories()
        {
            return GetCategories(null);
        }
    }

}
