using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PAYNLSDK.Converters
{
    class BooleanConverter : JsonConverter
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
            return typeof(Boolean).GetTypeInfo().IsAssignableFrom(objectType);
        }
    }
}
