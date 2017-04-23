using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.Utilities
{
    public class ParameterValidator
    {
        public static void IsNotEmpty(string param, string paramName)
        {
            if (String.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentException(string.Format("Invalid parameter {0}. Cannot be null, empty or consist of whitespace only", paramName),"paramName");
               
            }
        }

        public static void IsNotNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentException(string.Format("Invalid parameter '{0}'. Cannot be null", paramName));
            }
        }

        public static bool IsEmpty(string param)
        {
            return String.IsNullOrWhiteSpace(param);
        }

        public static bool IsNull(object param)
        {
            return (param == null);
        }

        public static bool IsNonEmptyInt(int? param)
        {
            return (param == null);
        }

    }
}
