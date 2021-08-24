using System;

namespace PAYNLSDK.Converters
{
    internal class ProductTypeConverter : EnumConversionBase
    {
        public override Type EnumType => typeof(Enums.ProductType);

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
