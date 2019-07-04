using System.Threading.Tasks;

namespace PAYNLSDK.Services
{
    public interface IUtilityService
    {
        Task<bool> ValidatePayIPAsync(string ipAddress);
        Task<bool> ValidateBankAccountNumberAsync(string bankAccountNumber, bool international);
        Task<bool> ValidateIBANAsync(string iban);
        Task<bool> ValidateSWIFTAsync(string swift);
        Task<bool> ValidateKVKAsync(string kvk);
        Task<bool> ValidateVATAsync(string vat);
        Task<bool> ValidateSOFIAsync(string sofi);
    }
}
