using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System;

namespace PAYNLSDK.Converters
{
    abstract public class EnumConversionBase : JsonConverter
    {
        abstract public Type EnumType { get; }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return EnumUtil.ToEnum(serializer.Deserialize<string>(reader), EnumType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var result = EnumUtil.ToEnumString(value, EnumType);
            writer.WriteValue(result);
            return;
        }
    }

    public class GenderConverter : EnumConversionBase
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

    public class TaxClassConverter : EnumConversionBase
    {
        public override Type EnumType
        {
            get { return typeof(Enums.TaxClass); }
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductTypeConverter : EnumConversionBase
    {
        public override Type EnumType
        {
            get { return typeof(Enums.ProductType); }
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
