using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.Converters
{
    public class TimestampConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                var dateTime = (DateTime)value;
                if (dateTime.Kind == DateTimeKind.Unspecified)
                {
                    throw new JsonSerializationException("Cannot convert date time with an unspecified kind");
                }
                if (dateTime.Kind != DateTimeKind.Utc)
                {
                    throw new JsonSerializationException("Given date time MUST be of the Utc kind");
                }
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                long timestamp = (long)dateTime.Subtract(epoch).TotalSeconds;
                writer.WriteValue(timestamp);
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
                double timestamp;
                string timeString = (string)reader.Value;
                // Try to parse the input as a double.
                try
                {
                    timestamp = Double.Parse(timeString);
                    // Format our new DateTime object to start at the UNIX Epoch
                    System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

                    // Add the timestamp (number of seconds since the Epoch) to be converted
                    dateTime = dateTime.AddSeconds(timestamp);
                    return dateTime;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            if (reader.TokenType == JsonToken.Integer)
            {
                double timestamp = (double)reader.Value;
                // Format our new DateTime object to start at the UNIX Epoch
                System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

                // Add the timestamp (number of seconds since the Epoch) to be converted
                dateTime = dateTime.AddSeconds(timestamp);
                return dateTime;
            }
            if (reader.TokenType == JsonToken.Float)
            {
                double timestamp = (double)reader.Value;
                // Format our new DateTime object to start at the UNIX Epoch
                System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

                // Add the timestamp (number of seconds since the Epoch) to be converted
                dateTime = dateTime.AddSeconds(timestamp);
                return dateTime;
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
