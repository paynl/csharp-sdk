using System;
using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Service.GetCategories
{
    public class Response : ResponseBase
    {
        public PAYNLSDK.Objects.ServiceCategory[] ServiceCategories { get; set; }
    }
}
