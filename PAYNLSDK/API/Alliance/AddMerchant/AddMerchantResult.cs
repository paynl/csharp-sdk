using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.API.Alliance.AddMerchant
{
    public class AddMerchantResult
    {

        public string success { get; set; }
        public string error_field { get; set; }
        public string error_message { get; set; }
        public string merchantId { get; set; }
        public string merchantToken { get; set; }
        public Account[] accounts { get; set; }


        public class Account
        {
            public string accountId { get; set; }
            public string email { get; set; }
        }

    }
}