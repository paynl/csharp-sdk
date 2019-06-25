using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.Converters
{
    class ErrorIdConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string result = serializer.Deserialize<string>(reader);
            if (result == String.Empty)
            {
                return 0;
            }
            try
            {
                return Int32.Parse(result);
            }
            catch (Exception e)
            {
                throw new JsonSerializationException(String.Format("Unexpected conversion '{0}' when parsing errorId.", result));
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
