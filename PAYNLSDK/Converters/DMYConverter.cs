using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.Converters
{
    internal class DMYConverter : JsonConverter
    {
        private const string Format = "dd-MM-yyyy";
        private static readonly string[] ParseFormats = {
                                       // - argument.
                                       "d-M-yyyy", "dd-MM-yyyy",
                                       // Slash argument.
                                       "d/M/yyyy", "dd/MM/yyyy"
                                   };
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is DateTime dateTime))
            {
                throw new JsonSerializationException("Expected value of type 'DateTime'.");
            }

            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                throw new JsonSerializationException("Cannot convert date time with an unspecified kind");
            }
            var convertedDateTime = dateTime.ToString(Format);
            writer.WriteValue(convertedDateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return null;
                case JsonToken.Date:
                {
                    var dateTime = (DateTime)reader.Value;
                    if (dateTime.Kind == DateTimeKind.Unspecified)
                    {
                        throw new JsonSerializationException("Parsed date time is not in the expected RFC3339 format");
                    }
                    return dateTime;
                }
                case JsonToken.String:
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
                default:
                    throw new JsonSerializationException($"Unexpected token '{reader.TokenType}' when parsing date.");
            }
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
