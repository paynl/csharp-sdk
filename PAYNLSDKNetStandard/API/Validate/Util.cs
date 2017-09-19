using Newtonsoft.Json;
using PAYNLSDK.Net;
using System;

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

        public bool ValidatePayIP(string ipAddress)
        {
            IsPayServerIp.Request request = new IsPayServerIp.Request();
            request.IpAddress = ipAddress;
            Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public bool ValidateBankAccountNumber(string bankAccountNumber, bool international)
        {
            if (international)
            {
                BankAccountNumberInternational.Request request = new BankAccountNumberInternational.Request();
                request.BankAccountNumber = bankAccountNumber;
                Client.PerformRequestAsync(request);
                return request.Response.result;
            }
            else
            {
                BankAccountNumber.Request request = new BankAccountNumber.Request();
                request.BankAccountNumber = bankAccountNumber;
                Client.PerformRequestAsync(request);
                return request.Response.result;
            }
        }

        public bool ValidateIBAN(string iban)
        {
            IBAN.Request request = new IBAN.Request();
            request.IBAN = iban;
            Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public bool ValidateSWIFT(string swift)
        {
            SWIFT.Request request = new SWIFT.Request();
            request.SWIFT = swift;
            Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public bool ValidateKVK(string kvk)
        {
            KVK.Request request = new KVK.Request();
            request.KVK = kvk;
            Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public bool ValidateVAT(string vat)
        {
            VAT.Request request = new VAT.Request();
            request.VAT = vat;
            Client.PerformRequestAsync(request);
            return request.Response.result;
        }

        public bool ValidateSOFI(string sofi)
        {
            SOFI.Request request = new SOFI.Request();
            request.SOFI = sofi;
            Client.PerformRequestAsync(request);
            return request.Response.result;
        }

    }
}
