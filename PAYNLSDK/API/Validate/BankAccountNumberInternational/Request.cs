﻿using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Validate.BankAccountNumberInternational
{
    public class Request : RequestBase
    {
        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        public override bool RequiresApiToken
        {
            get
            {
                return false;// base.RequiresApiToken;
            }
        }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "Validate"; }
        }

        public override string Method
        {
            get { return "BankAccountNumberInternational"; }
        }
        
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotEmpty(BankAccountNumber, "bankAccountNumber");
            nvc.Add("bankAccountNumber", BankAccountNumber);

            return nvc;
        }

        public Response Response { get { return (Response)response; } }

        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}
