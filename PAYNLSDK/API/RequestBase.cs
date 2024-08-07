﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace PAYNLSDK.API
{
    public abstract class RequestBase
    {
        /// <summary>
        /// Indicator stating whether or not a API Token is required for a specific request
        /// </summary>
        public virtual bool RequiresApiToken { get { return true; } }

        /// <summary>
        /// PAYNL CORE
        /// </summary>
        public static string Core { get; set; }

        /// <summary>
        /// PAYNL CORES
        /// </summary>
        public static Dictionary<string, string> GetCores()
        {
            var cores = new Dictionary<string, string>();
            cores.Add("Core1 (" + PAYNLSDK.API.RequestBase.Core1 + ")", PAYNLSDK.API.RequestBase.Core1Label);
            cores.Add("Core2 (" + PAYNLSDK.API.RequestBase.Core2 + ")", PAYNLSDK.API.RequestBase.Core2Label);
            cores.Add("Core3 (" + PAYNLSDK.API.RequestBase.Core3 + ")", PAYNLSDK.API.RequestBase.Core3Label);
            cores.Add("Core4 (" + PAYNLSDK.API.RequestBase.Core4 + ")", PAYNLSDK.API.RequestBase.Core4Label);
            return cores;
        }

        /// <summary>
        /// PAYNL Cores
        /// </summary>
        public static readonly string Core1 = "https://connect.pay.nl";
        public static readonly string Core1Label = "Connect.pay.nl (Default)";
        public static readonly string Core2 = "https://connect.achterelkebetaling.nl";
        public static readonly string Core2Label = "Achterelkebetaling.nl";
        public static readonly string Core3 = "https://connect.payments.nl";
        public static readonly string Core3Label = "Payments.nl";
        public static readonly string Core4 = "https://rest-api.pay.nl";
        public static readonly string Core4Label = "Pay.nl";


        /// <summary>
        /// Indicator stating whether or not a Service ID is required for a specific request
        /// </summary>
        public virtual bool RequiresServiceId { get { return false; } }

        /// <summary>
        /// PAYNL API TOKEN
        /// </summary>
        public static string ApiToken { get; set; }

        /// <summary>
        /// PAYNL Service ID
        /// </summary>
        public static string ServiceId { get; set; }

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
        /// COntroller method for this request
        /// </summary>
        public abstract string Method { get; }

        /// <summary>
        /// Extra querystring parameters used for this request
        /// </summary>
        public abstract string Querystring { get; }

        /// <summary>
        /// Returns a NameValueCollection of all paramaters used for this call.
        /// </summary>
        /// <returns>Name Value collection of parameters</returns>
        public virtual NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();
            if (RequiresApiToken)
            {
                if (!String.IsNullOrEmpty(ApiToken))
                {
                    nvc.Add("token", ApiToken);
                }
            }

            if (RequiresServiceId)
            {
                if (!String.IsNullOrEmpty(ServiceId))
                {
                    nvc.Add("serviceId", ServiceId);
                }
            }


            return nvc;
        }

        /// <summary>
        /// Transform NameValueCollection to a querystring
        /// </summary>
        /// <returns>appendable querystring</returns>
        public string ToQueryString()
        {
            NameValueCollection nvc = GetParameters();
            if (nvc.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            // TODO: add "?" if GET?

            bool first = true;

            foreach (string key in nvc.AllKeys)
            {
                foreach (string value in nvc.GetValues(key))
                {
                    if (!first)
                    {
                        sb.Append("&");
                    }

                    sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));

                    first = false;
                }
            }

            return sb.ToString();
        }

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
                SetResponse();
            }
        }

        /// <summary>
        /// Load the raw response and perform any actions along with it.
        /// </summary>
        public abstract void SetResponse();
    }

}
