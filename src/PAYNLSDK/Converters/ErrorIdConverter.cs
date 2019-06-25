using Newtonsoft.Json;
using System;

namespace PAYNLSDK.Converters
{
    class ErrorIdConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = serializer.Deserialize<string>(reader);
            if (result == string.Empty)
            {
                return 0;
            }
            try
            {
                return int.Parse(result);
            }
            catch
            {
                throw new JsonSerializationException(string.Format("Unexpected conversion '{0}' when parsing errorId.", result));
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            //if (CanConvert(value.GetType()))
            //{
                serializer.Serialize(writer, value);
            //}
            //throw new JsonSerializationException(String.Format("Can't serialize type {0} to Integer.", value.GetType()));
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(int).IsAssignableFrom(objectType);
        }
    }
}
