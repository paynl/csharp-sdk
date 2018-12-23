using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace PayNLSdk.API.Statistics.GetManagement
{
    public abstract class GetStatsResultBase
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("arrLabelList")]
        public LabelList ArrLabelList { get; set; }

        [JsonProperty("totals")]
        public Totals Total { get; set; }

        [JsonProperty("totalRows")]
        public int TotalRows { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pageData")]
        public Pagedata PageData { get; set; }

        [JsonProperty("currency_symbol")]
        public string Currency_symbol { get; set; }

        public class LabelList
        {
            [JsonProperty("4")]
            public _4 _4 { get; set; }
        }

        public class _4
        {
            public string name { get; set; }
            public Cols cols { get; set; }
        }

        public class Cols
        {
            public string num { get; set; }

            public decimal avg_pay { get; set; }
            public string org { get; set; }
            public string org_vat { get; set; }
            public string org_ext { get; set; }
            public string org_tot { get; set; }
            public decimal cst { get; set; }
            public string pay { get; set; }
        }

        public class Totals
        {
            [JsonProperty("4")]
            public Data _4 { get; set; }
        }

        public class Pagedata
        {
            public Colors colors { get; set; }
        }

        public class Colors
        {
            public string COLOR_1 { get; set; }
            public string COLOR_2 { get; set; }
            public string COLOR_3 { get; set; }
            public string COLOR_4 { get; set; }
            public string COLOR_5 { get; set; }
            public string COLOR_6 { get; set; }
            public string COLOR_7 { get; set; }
            public string COLOR_8 { get; set; }
            public string COLOR_9 { get; set; }
            public string COLOR_10 { get; set; }
            public string COLOR_11 { get; set; }
            public string COLOR_12 { get; set; }
            public string COLOR_13 { get; set; }
            public string COLOR_14 { get; set; }
            public string COLOR_15 { get; set; }
            public string COLOR_16 { get; set; }
            public string COLOR_17 { get; set; }
            public string COLOR_18 { get; set; }
            public string COLOR_19 { get; set; }
            public string COLOR_20 { get; set; }
            public string COLOR_21 { get; set; }
            public string COLOR_22 { get; set; }
            public string COLOR_23 { get; set; }
            public string COLOR_24 { get; set; }
            public string COLOR_25 { get; set; }
            public string COLOR_26 { get; set; }
            public string COLOR_27 { get; set; }
            public string COLOR_28 { get; set; }
            public string COLOR_29 { get; set; }
            public string COLOR_30 { get; set; }
            public string COLOR_31 { get; set; }
            public string COLOR_32 { get; set; }
            public string COLOR_33 { get; set; }
            public string COLOR_34 { get; set; }
            public string COLOR_35 { get; set; }
            public string COLOR_36 { get; set; }
        }

        public class StatsData
        {
            public string Id { get; set; }
            [JsonProperty("Label")]
            public string GroupedBy { get; set; }
            public StatsLine[] Data { get; set; }
        }

        public class StatsLine
        {
            public string Id { get; set; }
            [JsonProperty("Label")]
            public string Type { get; set; }
            public Data Data { get; set; }
        }

        public class Data
        {
            [JsonProperty("sum")]
            public string sum { get; set; }
            [JsonProperty("cst")]
            public string cst { get; set; }
            [JsonProperty("num")]
            public string num { get; set; }
            [JsonProperty("avg_dur")]
            public string avg_dur { get; set; }
            [JsonProperty("avg_pay")]
            public string avg_pay { get; set; }
            [JsonProperty("pay")]
            public string pay { get; set; }
            [JsonProperty("org")]
            public string org { get; set; }
            [JsonProperty("org_vat")]
            public string org_vat { get; set; }
            [JsonProperty("org_ext")]
            public string org_ext { get; set; }
            [JsonProperty("org_tot")]
            public decimal org_tot { get; set; }
        }
    }

    /// <summary>
    /// Class DecimalConverter.
    /// </summary>
    /// <remarks>https://stackoverflow.com/q/24051206/97615</remarks>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    internal class DecimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal) || objectType == typeof(decimal?));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            switch (token.Type)
            {
                case JTokenType.Float:
                case JTokenType.Integer:
                    return token.ToObject<decimal>();
                case JTokenType.String when decimal.TryParse(token.ToString(), System.Globalization.NumberStyles.AllowParentheses, System.Globalization.CultureInfo.CurrentCulture, out decimal d):
                    return d;
                case JTokenType.String:
                case JTokenType.Null when objectType == typeof(decimal?):
                    return null;
                default:
                    throw new JsonSerializationException($"Unexpected token type: {token.Type}");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            decimal? d = default(decimal?);
            if (value != null)
            {
                d = value as decimal?;
                if (d.HasValue) // If value was a decimal?, then this is possible
                {
                    d = new decimal?(new decimal(decimal.ToDouble(d.Value))); // The ToDouble-conversion removes all unnessecary precision
                }
            }
            JToken.FromObject(d).WriteTo(writer);
        }
    }
}

