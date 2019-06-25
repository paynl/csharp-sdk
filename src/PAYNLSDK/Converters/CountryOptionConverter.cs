using Newtonsoft.Json;
using PAYNLSDK.Objects;
using System;
using System.Collections.Generic;

namespace PAYNLSDK.Converters
{
    class CountryOptionConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var dict = serializer.Deserialize<Dictionary<string, CountryOption>>(reader);
                return dict;
            }
            throw new JsonSerializationException(string.Format("Unexpected token '{0}' when parsing country options.", reader.TokenType));
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
