using Newtonsoft.Json;
using PAYNLSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.Converters
{
    internal class CountryOptionConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var dict = serializer.Deserialize<Dictionary<string, CountryOption>>(reader);
                return dict;
            }
            throw new JsonSerializationException(String.Format("Unexpected token '{0}' when parsing country options.", reader.TokenType));

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(CountryOptions).IsAssignableFrom(objectType);
        }
    }
}
