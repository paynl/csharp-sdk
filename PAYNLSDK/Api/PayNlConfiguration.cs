using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.API
{
    public class PayNlConfiguration : IPayNlConfiguration
    {
        public PayNlConfiguration()
        {
        }
        public PayNlConfiguration(string serviceId, string apiToken)
        {
            ServiceId = serviceId;
            ApiToken = apiToken;
        }

        /// <summary>
        /// PAYNL Service ID
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// PAYNL API TOKEN
        /// </summary>
        public string ApiToken { get; set; }
    }
}
