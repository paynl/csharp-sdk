using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.API.Language
{
    public class GetAllResult
    {
        public Language[] Languages { get; set; }

        public class Language
        {
            public string id { get; set; }
            public string name { get; set; }
            public string abbreviation { get; set; }
            public string available { get; set; }
            public string fallback_language_id { get; set; }
            public string created { get; set; }
            public string created_by { get; set; }
            public string modified { get; set; }
            public string modified_by { get; set; }
        }

    }
}
