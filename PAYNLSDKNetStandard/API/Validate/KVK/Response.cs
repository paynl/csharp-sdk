using Newtonsoft.Json;
using PAYNLSDK.Converters;
using System;

namespace PAYNLSDK.API.Validate.KVK
{
    public class Response : ResponseBase
    {
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}
