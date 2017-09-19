using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.Converters
{
    class YMDConverter : JsonConverter
    {
        private const string Format = "yyyy-MM-dd";
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                var dateTime = (DateTime)value;
                if (dateTime.Kind == DateTimeKind.Unspecified)
                {
                    throw new JsonSerializationException("Cannot convert date time with an unspecified kind");
                }
                string convertedDateTime = dateTime.ToString(Format);
                writer.WriteValue(convertedDateTime);
            }
            else
            {
                throw new JsonSerializationException("Expected value of type 'DateTime'.");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.Date)
            {
                var dateTime = (DateTime)reader.Value;
                if (dateTime.Kind == DateTimeKind.Unspecified)
                {
                    throw new JsonSerializationException("Parsed date time is not in the expected RFC3339 format");
                }
                return dateTime;
            }

            if (reader.TokenType == JsonToken.String)
            {
                string timeString = (string)reader.Value;
                if (!ParameterValidator.IsEmpty(timeString))
                {
                    var dateTime = DateTime.Parse(timeString);
                    return dateTime;
                }
                return null;
            }
            throw new JsonSerializationException(String.Format("Unexpected token '{0}' when parsing date.", reader.TokenType));
        }

        public override bool CanConvert(Type objectType)
        {
            Type t = (Reflection.IsNullable(objectType))
               ? Nullable.GetUnderlyingType(objectType)
               : objectType;

            return t == typeof(DateTime);
        }
    }
}
