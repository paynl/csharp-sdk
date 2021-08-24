using System;

namespace PAYNLSDK.Converters
{
    internal class GenderConverter : EnumConversionBase
    {
        public override Type EnumType
        {
            get { return typeof(Enums.Gender); }
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
