using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.PaymentProfile.GetAll
{
    public class Response : ResponseBase
    {
        public PAYNLSDK.Objects.PaymentProfile[] PaymentProfiles { get; set; }
    }
}
