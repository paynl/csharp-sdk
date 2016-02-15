using System;
using Newtonsoft.Json;

namespace PAYNLSDK.API.PaymentMethod.Get
{
    public class Response : ResponseBase
    {
        public PAYNLSDK.Objects.PaymentMethod PaymentMethod { get; set; }

    }
}
