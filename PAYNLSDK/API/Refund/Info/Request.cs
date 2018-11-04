using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.Refund.Info
{
    /// <summary>
    /// 
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// create new instance
        /// </summary>
        /// <param name="refundId">Refund ID</param>
        public Request(string refundId)
        {
            this.RefundId = refundId;
        }

        /// <summary>
        /// The refund ID.
        /// </summary>
        public string RefundId { get; set; }

        /* overrides */
        /// <summary>
        /// 
        /// </summary>
        public override int Version
        {
            get { return 3; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Controller
        {
            get { return "Refund"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Method
        {
            get { return "info"; }
        }

      
        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresApiToken => true;

        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresServiceId => true;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotNull(RefundId, "RefundId");
            nvc.Add("refundId", RefundId);

            return nvc;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
            if (!Response.Request.Result)
            {
                // toss
                throw new PayNlException(Response.Request.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Response Response => (Response)response;
    }
}
