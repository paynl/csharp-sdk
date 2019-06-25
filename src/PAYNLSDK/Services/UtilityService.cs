using System.Threading.Tasks;

namespace PAYNLSDK.Services
{
    public class UtilityService : IUtilityService
    {
        public IClientService ClientService { get; }

        public UtilityService(IClientService clientService)
        {
            ClientService = clientService;
        }

        public async Task<bool> ValidatePayIPAsync(string ipAddress)
        {
            var request = new API.Validate.IsPayServerIp.Request
            {
                IpAddress = ipAddress
            };

            await ClientService.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateBankAccountNumberAsync(string bankAccountNumber, bool international)
        {
            if (international)
            {
                var request = new API.Validate.BankAccountNumberInternational.Request
                {
                    BankAccountNumber = bankAccountNumber
                };
                await ClientService.PerformRequestAsync(request);
                return request.Response.result;
            }
            else
            {
                var request = new API.Validate.BankAccountNumber.Request
                {
                    BankAccountNumber = bankAccountNumber
                };
                await ClientService.PerformRequestAsync(request);
                return request.Response.result;
            }
        }

        public async Task<bool> ValidateIBANAsync(string iban)
        {
            var request = new API.Validate.IBAN.Request
            {
                IBAN = iban
            };
            await ClientService.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateSWIFTAsync(string swift)
        {
            var request = new API.Validate.SWIFT.Request
            {
                SWIFT = swift
            };
            await ClientService.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateKVKAsync(string kvk)
        {
            var request = new API.Validate.KVK.Request
            {
                KVK = kvk
            };
            await ClientService.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateVATAsync(string vat)
        {
            var request = new API.Validate.VAT.Request
            {
                VAT = vat
            };
            await ClientService.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateSOFIAsync(string sofi)
        {
            var request = new API.Validate.SOFI.Request
            {
                SOFI = sofi
            };
            await ClientService.PerformRequestAsync(request);
            return request.Response.result;
        }
    }
}
