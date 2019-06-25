using Newtonsoft.Json;
using System;

namespace PAYNLSDK.API.Transaction.Approve
{
    public class Response : ResponseBase
    {

        [JsonProperty("message")]
        public string Message { get; protected set; }
    }
}
