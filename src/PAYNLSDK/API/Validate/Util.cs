using Newtonsoft.Json;
using PAYNLSDK.Net;
using System.Threading.Tasks;

namespace PAYNLSDK.API.Validate
{
    public class Util
    {
        public IClient Client { get; set; }

        private JsonSerializerSettings serializerSettings;
        public JsonSerializerSettings SerializerSettings
        {
            get
            {
                if (serializerSettings == null)
                {
                    serializerSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    };
                }
                return serializerSettings;
            }
            set
            {
                serializerSettings = value;
            }
        }

        public Util(IClient client) : this(client, null)
        {
        }

        public Util(IClient client, JsonSerializerSettings serializerSettings)
        {
            Client = client;
            SerializerSettings = serializerSettings;
        }

        public async Task<bool> ValidatePayIPAsync(string ipAddress)
        {
            var request = new IsPayServerIp.Request
            {
                IpAddress = ipAddress
            };
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateBankAccountNumberAsync(string bankAccountNumber, bool international)
        {
            if (international)
            {
                var request = new BankAccountNumberInternational.Request
                {
                    BankAccountNumber = bankAccountNumber
                };
                await Client.PerformRequestAsync(request);
                return request.Response.result;
            }
            else
            {
                var request = new BankAccountNumber.Request
                {
                    BankAccountNumber = bankAccountNumber
                };
                await Client.PerformRequestAsync(request);
                return request.Response.result;
            }
        }

        public async Task<bool> ValidateIBANAsync(string iban)
        {
            var request = new IBAN.Request
            {
                IBAN = iban
            };
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateSWIFTAsync(string swift)
        {
            var request = new SWIFT.Request
            {
                SWIFT = swift
            };
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateKVKAsync(string kvk)
        {
            var request = new KVK.Request
            {
                KVK = kvk
            };
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateVATAsync(string vat)
        {
            var request = new VAT.Request
            {
                VAT = vat
            };
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateSOFIAsync(string sofi)
        {
            var request = new SOFI.Request
            {
                SOFI = sofi
            };
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }
    }
}
