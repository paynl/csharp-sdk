using Newtonsoft.Json;
using System;

namespace PAYNLSDK.Converters
{
    internal abstract class EnumConversionBase : JsonConverter
    {
        public abstract Type EnumType { get; }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Enums.EnumUtil.ToEnum(serializer.Deserialize<string>(reader), EnumType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string result = Enums.EnumUtil.ToEnumString(value, EnumType);
            writer.WriteValue(result);
        }
    }
}
