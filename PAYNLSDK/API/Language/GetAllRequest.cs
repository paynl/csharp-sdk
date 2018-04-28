using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.API.Language
{
    public class GetAllRequest : RequestBase
    {
        public override int Version => 2;
        public override string Controller => "Language";
        public override string Method => "GetAll";
        public override NameValueCollection GetParameters()
        {
            return new NameValueCollection();
        }

        protected override void PrepareAndSetResponse()
        {
            // do nothing
        }
    }
}
