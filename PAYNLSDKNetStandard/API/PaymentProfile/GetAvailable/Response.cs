using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.PaymentProfile.GetAvailable
{
    public class Response : ResponseBase
    {
        public PAYNLSDK.Objects.PaymentProfile[] PaymentProfiles { get; set; }
    }
}
