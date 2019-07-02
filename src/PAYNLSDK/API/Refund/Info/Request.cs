using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using PAYNLSDK.Exceptions;

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
        public override string Querystring
        {
            get { return ""; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresApiToken
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresServiceId
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            var nvc = base.GetParameters();

            ParameterValidator.IsNotNull(RefundId, "RefundId");
            nvc.Add("refundId", RefundId);

            return nvc;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
            if (!Response.Request.Result)
            {
                // toss
                throw new ErrorException(Response.Request.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Response Response { get { return (Response)response; } }
    }
}
