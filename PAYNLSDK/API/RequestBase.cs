using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;
using System.Text;

namespace PAYNLSDK.API
{
    /// <summary>
    /// The base class to perform a request to the Pay.NL api
    /// </summary>
    public abstract class RequestBase
    {
        /// <summary>
        /// Indicator stating whether or not a API Token is required for a specific request
        /// </summary>
        public virtual bool RequiresApiToken { get { return true; } }

        /// <summary>
        /// Indicator stating whether or not a Service ID is required for a specific request
        /// </summary>
        public virtual bool RequiresServiceId { get { return false; } }

        /// <summary>
        /// The configuration with the ServiceId & Token
        /// </summary>
        public IPayNlConfiguration Configuration { get; set; }
        
        /// <summary>
        /// Return as JSON
        /// </summary>
        /// <returns>JSON string</returns>
        public override string ToString()
        {
            //return base.ToString();
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// URL used to perform this specific request
        /// </summary>
        public string Url
        {
            get { return string.Format("v{0}/{1}/{2}/json", Version, Controller, Method); }
        }

        /// <summary>
        /// Api Version for this request
        /// </summary>
        public abstract int Version { get; }

        /// <summary>
        /// Controller used for this request
        /// </summary>
        public abstract string Controller { get; }

        /// <summary>
        /// Controller method for this request
        /// </summary>
        public abstract string Method { get; }

        /// <summary>
        /// Extra querystring parameters used for this request
        /// </summary>
        public abstract string Querystring { get; }

        /// <summary>
        /// Get all properties as a nameValueCollection
        /// </summary>
        public abstract NameValueCollection GetParameters();

        /// <summary>
        /// Response belonging to this request
        /// </summary>
        protected ResponseBase response;

        /// <summary>
        /// The raw response stroing
        /// </summary>
        protected string rawResponse;

        /// <summary>
        /// Raw response data
        /// </summary>
        public string RawResponse
        {
            get
            {
                return rawResponse;
            }
            set
            {
                rawResponse = value;
                PrepareAndSetResponse();
            }
        }

        /// <summary>
        /// Load the raw response and perform any actions along with it.
        /// </summary>
        protected abstract void PrepareAndSetResponse();
    }

}
