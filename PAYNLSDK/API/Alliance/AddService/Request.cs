using System.Collections.Specialized;

namespace PAYNLSDK.API.Alliance.AddService
{
    /// <summary>
    /// Class Request for a new Service.
    /// </summary>
    /// <seealso cref="PAYNLSDK.API.RequestBase" />
    public class Request : RequestBase
    {
        public override int Version => 4;
        public override string Controller => "Alliance";
        public override string Method => "addService";
        public override NameValueCollection GetParameters()
        {
            var retval = new NameValueCollection { };
            retval.Add("merchantId", MerchantId);
            retval.Add("name", Name);
            retval.Add("description", Description);
            retval.Add("categoryId", CategoryId);
            retval.Add("publication", Publication);

            return retval;
        }

        /// <summary>
        /// Gets or sets the merchant identifier.
        /// </summary>
        /// <value>The merchant identifier.</value>
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets the description of the way you are using the payment methods
        /// </summary>
        /// <value>The publication.</value>
        public string Publication { get; set; }

        /// <summary>
        /// Gets or sets The ID of the category that best descriptions your service. 
        /// For a list of available categories, see API_Service_v1::getCategories().
        /// </summary>
        /// <value>The category identifier.</value>
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the description of the service. It is important to be as acurate as possible.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }


        /// <summary>
        /// Load the raw response and perform any actions along with it.
        /// </summary>
        protected override void PrepareAndSetResponse()
        {
            // do nothing   
        }
    }
}
