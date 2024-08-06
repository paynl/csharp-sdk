using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.Converters
{
    public class DMYConverter : JsonConverter
    {
        private const string Format = "dd-MM-yyyy";
        private static string[] ParseFormats = {
                                       // - argument.
                                       "d-M-yyyy", "dd-MM-yyyy",
                                       // Slash argument.
                                       "d/M/yyyy", "dd/MM/yyyy"
                                   };
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                var dateTime = (DateTime)value;
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
                DateTime dateTime;
                /*string[] formats = { "d/M/yyyy", "dd/MM/yyyy", "d-M-yyyy", "dd-MM-yyyy" };*/
                string timeString = (string)reader.Value;
                if (!ParameterValidator.IsEmpty(timeString))
                {
                    if (DateTime.TryParseExact(timeString, ParseFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime))
                    {
                        // Gelukt we kunnen doorgaan
                        return dateTime;
                    }
                    else
                    {
                        // De opgegeven timeString is niet juist.
                        return null;
                    }

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
