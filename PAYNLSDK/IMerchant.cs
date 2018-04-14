using PAYNLSDK.API.Merchant.Add;
using PAYNLSDK.API.Merchant.Get;

namespace PAYNLSDK
{
    public interface IMerchant
    {
        API.Merchant.Add.Response Create(API.Merchant.Add.Request request);
        API.Merchant.Get.Response Get(string merchantId);
    }
}