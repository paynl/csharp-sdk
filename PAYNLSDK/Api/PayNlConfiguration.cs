using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.API
{
    public class PayNlConfiguration : IPayNlConfiguration
    {
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
