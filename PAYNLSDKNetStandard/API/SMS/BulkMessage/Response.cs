using Newtonsoft.Json;
using PAYNLSDK.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.API.SMS.BulkMessage
{
    public class Response : ResponseBase
    {
        [JsonProperty("result"),JsonConverter(typeof(BooleanConverter))]
        public bool result { get; protected set; }
    }
}
