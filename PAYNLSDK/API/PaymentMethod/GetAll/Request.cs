using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.PaymentMethod.GetAll
{
    /// <summary>
    /// This function returns an array containing all payment methods. 
    /// https://admin.pay.nl/docpanel/api/PaymentMethod/getAll/1
    /// </summary>
    public class Request : RequestBase
    {
        /// <inheritdoc />
        public override int Version
        {
            get { return 1; }
        }

        /// <inheritdoc />
        public override string Controller
        {
            get { return "PaymentMethod"; }
        }

        /// <inheritdoc />
        public override string Method
        {
            get { return "getAll"; }
        }

        /// <inheritdoc />
        public override string Querystring
        {
            get { return ""; }
        }
        
        public Response Response { get { return (Response)response; } }

        /// <inheritdoc />
        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            PAYNLSDK.Objects.PaymentMethod[] pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.PaymentMethod[]>(RawResponse);
            Response r = new Response
            {
                PaymentMethods = pm
            };
            response = r;
        }
    }
}
