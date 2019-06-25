using Newtonsoft.Json;
using System;

namespace PAYNLSDK.Converters
{
    class BooleanConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var result = serializer.Deserialize<int>(reader);
                return result == 1;
            }
            catch (Exception)
            {
                return bool.Parse(serializer.Deserialize<string>(reader));
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var result = Convert.ToBoolean(value);
            writer.WriteValue(result);
            return;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(bool).IsAssignableFrom(objectType);
        }
    }
}
