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
        /// <inheritdoc />
        protected override int Version => 2;
        /// <inheritdoc />
        protected override string Controller => "Language";
        /// <inheritdoc />
        protected override string Method => "GetAll";
        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            return new NameValueCollection();
        }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            // do nothing
        }
    }
}
