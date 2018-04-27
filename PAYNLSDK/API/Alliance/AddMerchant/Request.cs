using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.API.Alliance.AddMerchant
{
    public class Request : RequestBase
    {
        public override int Version => 4;
        public override string Controller => "Alliance";
        public override string Method => "addMerchant";
        public override NameValueCollection GetParameters()
        {
            var retval = new NameValueCollection { { "key", "value" } };
            return retval;
        }

        protected override void PrepareAndSetResponse()
        {
            // do nothing   
        }
    }
}
