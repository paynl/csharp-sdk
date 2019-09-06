using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.Converters
{
    public class YMDHISConverter : JsonConverter
    {
        private const string Format = "yyyy-MM-dd HH:mm:ss";
        private static string[] ParseFormats = {
                                       // - argument.
                                       "yyyy-M-d h:mm:ss tt", "yyyy-M-d h:mm tt", 
                                       "yyyy-MM-dd hh:mm:ss", "yyyy-M-d h:mm:ss", 
                                       "yyyy-M-d hh:mm tt", "yyyy-M-d hh tt", 
                                       "yyyy-M-d h:mm", "yyyy-M-d h:mm", 
                                       "yyyy-MM-dd hh:mm", "yyyy-M-dd hh:mm",

                                       "yyyy-M-d H:mm:ss tt", "yyyy-M-d H:mm tt", 
                                       "yyyy-MM-dd HH:mm:ss", "yyyy-M-d H:mm:ss", 
                                       "yyyy-M-d HH:mm tt", "yyyy-M-d HH tt", 
                                       "yyyy-M-d H:mm", "yyyy-M-d H:mm", 
                                       "yyyy-MM-dd HH:mm", "yyyy-M-dd HH:mm",

                                       // Slash argument.
                                       "yyyy/M/d h:mm:ss tt", "yyyy/M/d h:mm tt", 
                                       "yyyy/MM/dd hh:mm:ss", "yyyy/M/d h:mm:ss", 
                                       "yyyy/M/d hh:mm tt", "yyyy/M/d hh tt", 
                                       "yyyy/M/d h:mm", "yyyy/M/d h:mm", 
                                       "yyyy/MM/dd hh:mm", "yyyy/M/dd hh:mm",
                                       
                                       "yyyy/M/d H:mm:ss tt", "yyyy/M/d H:mm tt", 
                                       "yyyy/MM/dd HH:mm:ss", "yyyy/M/d H:mm:ss", 
                                       "yyyy/M/d HH:mm tt", "yyyy/M/d HH tt", 
                                       "yyyy/M/d H:mm", "yyyy/M/d H:mm", 
                                       "yyyy/MM/dd HH:mm", "yyyy/M/dd HH:mm"
                                   };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                var dateTime = (DateTime)value;
                if (dateTime.Kind == DateTimeKind.Unspecified)
                {
                    // Gives too many errors. We'll just assume everything is ok and handle everything "as is"... -sigh-
                    //throw new JsonSerializationException("Cannot convert date time with an unspecified kind");
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
                DateTime dateTime;
                /*
                                string[] formats = {
                                                       // - argument.
                                                       "yyyy-M-d h:mm:ss tt", "yyyy-M-d h:mm tt", 
                                                       "yyyy-MM-dd hh:mm:ss", "yyyy-M-d h:mm:ss", 
                                                       "yyyy-M-d hh:mm tt", "yyyy-M-d hh tt", 
                                                       "yyyy-M-d h:mm", "yyyy-M-d h:mm", 
                                                       "yyyy-MM-dd hh:mm", "yyyy-M-dd hh:mm",

                                                       "yyyy-M-d H:mm:ss tt", "yyyy-M-d H:mm tt", 
                                                       "yyyy-MM-dd HH:mm:ss", "yyyy-M-d H:mm:ss", 
                                                       "yyyy-M-d HH:mm tt", "yyyy-M-d HH tt", 
                                                       "yyyy-M-d H:mm", "yyyy-M-d H:mm", 
                                                       "yyyy-MM-dd HH:mm", "yyyy-M-dd HH:mm",

                                                       // Slash argument.
                                                       "yyyy/M/d h:mm:ss tt", "yyyy/M/d h:mm tt", 
                                                       "yyyy/MM/dd hh:mm:ss", "yyyy/M/d h:mm:ss", 
                                                       "yyyy/M/d hh:mm tt", "yyyy/M/d hh tt", 
                                                       "yyyy/M/d h:mm", "yyyy/M/d h:mm", 
                                                       "yyyy/MM/dd hh:mm", "yyyy/M/dd hh:mm",

                                                       "yyyy/M/d H:mm:ss tt", "yyyy/M/d H:mm tt", 
                                                       "yyyy/MM/dd HH:mm:ss", "yyyy/M/d H:mm:ss", 
                                                       "yyyy/M/d HH:mm tt", "yyyy/M/d HH tt", 
                                                       "yyyy/M/d H:mm", "yyyy/M/d H:mm", 
                                                       "yyyy/MM/dd HH:mm", "yyyy/M/dd HH:mm"
                                                   };
                 */
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
