using Newtonsoft.Json;
using PAYNLSDK.Net;
using System;
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
                    serializerSettings = new JsonSerializerSettings(); 
                    serializerSettings.NullValueHandling = NullValueHandling.Ignore; 
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
            IsPayServerIp.Request request = new IsPayServerIp.Request();
            request.IpAddress = ipAddress;
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateBankAccountNumberAsync(string bankAccountNumber, bool international)
        {
            if (international)
            {
                BankAccountNumberInternational.Request request = new BankAccountNumberInternational.Request();
                request.BankAccountNumber = bankAccountNumber;
                await Client.PerformRequestAsync(request);
                return request.Response.result;
            }
            else
            {
                BankAccountNumber.Request request = new BankAccountNumber.Request();
                request.BankAccountNumber = bankAccountNumber;
                await Client.PerformRequestAsync(request);
                return request.Response.result;
            }
        }

        public async Task<bool> ValidateIBANAsync(string iban)
        {
            IBAN.Request request = new IBAN.Request();
            request.IBAN = iban;
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateSWIFTAsync(string swift)
        {
            SWIFT.Request request = new SWIFT.Request();
            request.SWIFT = swift;
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateKVKAsync(string kvk)
        {
            KVK.Request request = new KVK.Request();
            request.KVK = kvk;
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateVATAsync(string vat)
        {
            VAT.Request request = new VAT.Request();
            request.VAT = vat;
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public async Task<bool> ValidateSOFIAsync(string sofi)
        {
            SOFI.Request request = new SOFI.Request();
            request.SOFI = sofi;
            await Client.PerformRequestAsync(request);
            return request.Response.result;
        }

    }
}
