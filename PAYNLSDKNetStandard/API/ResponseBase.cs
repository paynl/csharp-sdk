using Newtonsoft.Json;
using PAYNLSDK.Objects;
using System;

namespace PAYNLSDK.API
{
    public abstract class ResponseBase
    {
        /// <summary>
        /// The Error if the request led to a failed response
        /// </summary>
        [JsonProperty("request")]
        public Error Request { get; protected set; }

        /// <summary>
        /// Return response as formatted JSON
        /// </summary>
        /// <returns>JSON string</returns>
        public override string ToString()
        {
            //return base.ToString();
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
