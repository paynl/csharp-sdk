using System;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Global

namespace PAYNLSDK.Utilities
{
    internal class ParameterValidator
    {
        internal static void IsNotEmpty(string param, string paramName)
        {
            if (String.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentException(string.Format("Invalid parameter {0}. Cannot be null, empty or consist of whitespace only", paramName), paramName);
            }
        }

        internal static void IsNotNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentException(string.Format("Invalid parameter '{0}'. Cannot be null", paramName), paramName);
            }
        }

        internal static bool IsEmpty(string param)
        {
            return String.IsNullOrWhiteSpace(param);
        }

        internal static bool IsNull(object param)
        {
            return (param == null);
        }

        internal static bool IsNonEmptyInt(int? param)
        {
            return (param != null);
        }

    }
}
