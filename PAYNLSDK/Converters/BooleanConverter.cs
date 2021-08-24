using Newtonsoft.Json;
using System;

namespace PAYNLSDK.Converters
{
    /// <summary>
    /// A boolean json converter for newtonsoft
    /// </summary>
    internal class BooleanConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var result = serializer.Deserialize<int>(reader);
                return (result == 1);
            }
            catch (Exception)
            {
                return Boolean.Parse(serializer.Deserialize<string>(reader));
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            bool result = Convert.ToBoolean(value);
            writer.WriteValue(result);
            return;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Boolean).IsAssignableFrom(objectType);
        }
    }
}
