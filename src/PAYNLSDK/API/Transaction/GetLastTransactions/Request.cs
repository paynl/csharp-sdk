﻿using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.Transaction.GetLastTransactions
{
    public class Request : RequestBase
    {
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("paid")]
        public bool? Paid { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        public override bool RequiresServiceId
        {
            get
            {
                return true;
            }
        }

        public override int Version
        {
            get { return 5; }
        }

        public override string Controller
        {
            get { return "Transaction"; }
        }

        public override string Method
        {
            get { return "getLastTransactions"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters()
        {
            NameValueCollection nvc = base.GetParameters();
            if (!ParameterValidator.IsNull(MerchantId))
            {
                nvc.Add("merchantId", MerchantId);
            }
            if (!ParameterValidator.IsNull(Paid))
            {
                nvc.Add("paid", ((bool)Paid) ? "1" : "0");
            }
            if (!ParameterValidator.IsNull(Limit))
            {
                nvc.Add("limit", Limit.ToString());
            }
            return nvc;
        }
        
        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}
