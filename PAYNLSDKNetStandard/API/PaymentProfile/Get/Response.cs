using System;
using Newtonsoft.Json;

namespace PAYNLSDK.API.PaymentProfile.Get
{
    public class Response : ResponseBase
    {
        public PAYNLSDK.Objects.PaymentProfile PaymentProfile { get; set; }

    }
}
