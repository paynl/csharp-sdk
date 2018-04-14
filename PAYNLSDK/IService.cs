using PAYNLSDK.API.Service.GetCategories;

namespace PAYNLSDK
{
    /// <summary>
    /// A 
    /// </summary>
    public interface IService
    {
        Response GetCategories(int? paymentOptionId = null);
    }
}