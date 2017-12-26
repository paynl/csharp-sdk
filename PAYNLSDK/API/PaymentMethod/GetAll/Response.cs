using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.PaymentMethod.GetAll
{
    public class Response : ResponseBase
    {
        /// <summary>
        /// 
        /// </summary>
        public PAYNLSDK.Objects.PaymentMethod[] PaymentMethods { get; set; }
    }
}
