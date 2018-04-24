using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.API.Alliance.GetMerchant
{
    public class Request : RequestBase
    {
        public override int Version => 4;
        public override string Controller => "Alliance";
        public override string Method => "GetMerchant";
        public override NameValueCollection GetParameters()
        {
            throw new NotImplementedException();
        }

        protected override void PrepareAndSetResponse()
        {
            throw new NotImplementedException();
        }
    }
}
