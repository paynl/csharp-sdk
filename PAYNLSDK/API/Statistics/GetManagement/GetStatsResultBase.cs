using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace PayNLSdk.API.Statistics.GetManagement
{
    /// <summary>
    /// Class GetStatsResultBase.
    /// </summary>
    public abstract class GetStatsResultBase
    {
        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>The login.</value>
        [JsonProperty("login")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the arr label list.
        /// </summary>
        /// <value>The arr label list.</value>
        [JsonProperty("arrLabelList")]
        public LabelList ArrLabelList { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        [JsonProperty("totals")]
        public Totals Total { get; set; }

        /// <summary>
        /// Gets or sets the total rows.
        /// </summary>
        /// <value>The total rows.</value>
        [JsonProperty("totalRows")]
        public int TotalRows { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the page data.
        /// </summary>
        /// <value>The page data.</value>
        [JsonProperty("pageData")]
        public Pagedata PageData { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        /// <value>The currency symbol.</value>
        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Class LabelList.
        /// </summary>
        public class LabelList
        {
            /// <summary>
            /// Gets or sets the 4.
            /// </summary>
            /// <value>The 4.</value>
            [JsonProperty("4")]
            public _4 _4 { get; set; }
        }

        /// <summary>
        /// Class _4.
        /// </summary>
        public class _4
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            [JsonProperty("name")]
            public string name { get; set; }

            /// <summary>
            /// Gets or sets the cols.
            /// </summary>
            /// <value>The cols.</value>
            [JsonProperty("cols")]
            public ColumnLabels ColumnLabels { get; set; }
        }

        /// <summary>
        /// Class Cols.
        /// </summary>
        public class ColumnLabels
        {
            /// <summary>
            /// Gets or sets the number.
            /// </summary>
            /// <value>The number.</value>
            [JsonProperty("num")]
            public string num { get; set; }

            /// <summary>
            /// Gets or sets the average pay.
            /// </summary>
            /// <value>The average pay.</value>
            [JsonProperty("avg_pay")]
            public string avg_pay { get; set; }

            /// <summary>
            /// Gets or sets the org.
            /// </summary>
            /// <value>The org.</value>
            [JsonProperty("org")]
            public string org { get; set; }

            /// <summary>
            /// Gets or sets the org vat.
            /// </summary>
            /// <value>The org vat.</value>
            [JsonProperty("org_vat")]
            public string org_vat { get; set; }

            /// <summary>
            /// Gets or sets the org ext.
            /// </summary>
            /// <value>The org ext.</value>
            [JsonProperty("org_ext")]
            public string org_ext { get; set; }

            /// <summary>
            /// Gets or sets the org tot.
            /// </summary>
            /// <value>The org tot.</value>
            [JsonProperty("org_tot")]
            public string org_tot { get; set; }

            /// <summary>
            /// Gets or sets the CST.
            /// </summary>
            /// <value>The CST.</value>
            [JsonProperty("cst")]
            public string cst { get; set; }

            /// <summary>
            /// Gets or sets the pay.
            /// </summary>
            /// <value>The pay.</value>
            [JsonProperty("pay")]
            public string pay { get; set; }
        }

        /// <summary>
        /// Class ColumnValues.
        /// </summary>
        public class ColumnValues
        {
            /// <summary>
            /// Gets or sets the number.
            /// </summary>
            /// <value>The number.</value>
            [JsonProperty("num")]
            public string num { get; set; }

            /// <summary>
            /// Gets or sets the average pay.
            /// </summary>
            /// <value>The average pay.</value>
            [JsonProperty("avg_pay")]
            public string avg_pay { get; set; }

            /// <summary>
            /// Gets or sets the org.
            /// </summary>
            /// <value>The org.</value>
            [JsonProperty("org")]
            public string org { get; set; }

            /// <summary>
            /// Gets or sets the org vat.
            /// </summary>
            /// <value>The org vat.</value>
            [JsonProperty("org_vat")]
            public string org_vat { get; set; }

            /// <summary>
            /// Gets or sets the org ext.
            /// </summary>
            /// <value>The org ext.</value>
            [JsonProperty("org_ext")]
            public string org_ext { get; set; }

            /// <summary>
            /// Gets or sets the org tot.
            /// </summary>
            /// <value>The org tot.</value>
            [JsonProperty("org_tot")]
            public string org_tot { get; set; }

            /// <summary>
            /// Gets or sets the CST.
            /// </summary>
            /// <value>The CST.</value>
            [JsonProperty("cst")]
            public string cst { get; set; }

            /// <summary>
            /// Gets or sets the pay.
            /// </summary>
            /// <value>The pay.</value>
            [JsonProperty("pay")]
            public string pay { get; set; }
        }

        /// <summary>
        /// Class Totals.
        /// </summary>
        public class Totals
        {
            /// <summary>
            /// Gets or sets the sub data - which is oddly called "4"
            /// </summary>
            /// <value>The 4.</value>
            [JsonProperty("4")] public Data _4 { get; set; }
        }

        /// <summary>
        /// Class Pagedata.
        /// </summary>
        public class Pagedata
        {
            /// <summary>
            /// Gets or sets the colors.
            /// </summary>
            /// <value>The colors.</value>
            [JsonProperty("pay")] public Colors colors { get; set; }
        }

        /// <summary>
        /// Class Colors.
        /// </summary>
        public class Colors
        {
            /// <summary>
            /// Gets or sets the color 1.
            /// </summary>
            /// <value>The color 1.</value>
            [JsonProperty("COLOR_1")] public string COLOR_1 { get; set; }
            /// <summary>
            /// Gets or sets the color 2.
            /// </summary>
            /// <value>The color 2.</value>
            [JsonProperty("COLOR_2")] public string COLOR_2 { get; set; }
            /// <summary>
            /// Gets or sets the color 3.
            /// </summary>
            /// <value>The color 3.</value>
            [JsonProperty("COLOR_3")] public string COLOR_3 { get; set; }
            /// <summary>
            /// Gets or sets the color 4.
            /// </summary>
            /// <value>The color 4.</value>
            [JsonProperty("COLOR_4")] public string COLOR_4 { get; set; }
            /// <summary>
            /// Gets or sets the color 5.
            /// </summary>
            /// <value>The color 5.</value>
            [JsonProperty("COLOR_5")] public string COLOR_5 { get; set; }
            /// <summary>
            /// Gets or sets the color 6.
            /// </summary>
            /// <value>The color 6.</value>
            [JsonProperty("COLOR_6")] public string COLOR_6 { get; set; }
            /// <summary>
            /// Gets or sets the color 7.
            /// </summary>
            /// <value>The color 7.</value>
            [JsonProperty("COLOR_7")] public string COLOR_7 { get; set; }
            /// <summary>
            /// Gets or sets the color 8.
            /// </summary>
            /// <value>The color 8.</value>
            [JsonProperty("COLOR_8")] public string COLOR_8 { get; set; }
            /// <summary>
            /// Gets or sets the color 9.
            /// </summary>
            /// <value>The color 9.</value>
            [JsonProperty("COLOR_9")] public string COLOR_9 { get; set; }
            /// <summary>
            /// Gets or sets the color 10.
            /// </summary>
            /// <value>The color 10.</value>
            [JsonProperty("COLOR_10")] public string COLOR_10 { get; set; }
            /// <summary>
            /// Gets or sets the color 11.
            /// </summary>
            /// <value>The color 11.</value>
            [JsonProperty("COLOR_11")] public string COLOR_11 { get; set; }
            /// <summary>
            /// Gets or sets the color 12.
            /// </summary>
            /// <value>The color 12.</value>
            [JsonProperty("COLOR_12")] public string COLOR_12 { get; set; }
            /// <summary>
            /// Gets or sets the color 13.
            /// </summary>
            /// <value>The color 13.</value>
            [JsonProperty("COLOR_13")] public string COLOR_13 { get; set; }
            /// <summary>
            /// Gets or sets the color 14.
            /// </summary>
            /// <value>The color 14.</value>
            [JsonProperty("COLOR_14")] public string COLOR_14 { get; set; }
            /// <summary>
            /// Gets or sets the color 15.
            /// </summary>
            /// <value>The color 15.</value>
            [JsonProperty("COLOR_15")] public string COLOR_15 { get; set; }
            /// <summary>
            /// Gets or sets the color 16.
            /// </summary>
            /// <value>The color 16.</value>
            [JsonProperty("COLOR_16")] public string COLOR_16 { get; set; }
            /// <summary>
            /// Gets or sets the color 17.
            /// </summary>
            /// <value>The color 17.</value>
            [JsonProperty("COLOR_17")] public string COLOR_17 { get; set; }
            /// <summary>
            /// Gets or sets the color 18.
            /// </summary>
            /// <value>The color 18.</value>
            [JsonProperty("COLOR_18")] public string COLOR_18 { get; set; }
            /// <summary>
            /// Gets or sets the color 19.
            /// </summary>
            /// <value>The color 19.</value>
            [JsonProperty("COLOR_19")] public string COLOR_19 { get; set; }
            /// <summary>
            /// Gets or sets the color 20.
            /// </summary>
            /// <value>The color 20.</value>
            [JsonProperty("COLOR_20")] public string COLOR_20 { get; set; }
            /// <summary>
            /// Gets or sets the color 21.
            /// </summary>
            /// <value>The color 21.</value>
            [JsonProperty("COLOR_21")] public string COLOR_21 { get; set; }
            /// <summary>
            /// Gets or sets the color 22.
            /// </summary>
            /// <value>The color 22.</value>
            [JsonProperty("COLOR_22")] public string COLOR_22 { get; set; }
            /// <summary>
            /// Gets or sets the color 23.
            /// </summary>
            /// <value>The color 23.</value>
            [JsonProperty("COLOR_23")] public string COLOR_23 { get; set; }
            /// <summary>
            /// Gets or sets the color 24.
            /// </summary>
            /// <value>The color 24.</value>
            [JsonProperty("COLOR_24")] public string COLOR_24 { get; set; }
            /// <summary>
            /// Gets or sets the color 25.
            /// </summary>
            /// <value>The color 25.</value>
            [JsonProperty("COLOR_25")] public string COLOR_25 { get; set; }
            /// <summary>
            /// Gets or sets the color 26.
            /// </summary>
            /// <value>The color 26.</value>
            [JsonProperty("COLOR_26")] public string COLOR_26 { get; set; }
            /// <summary>
            /// Gets or sets the color 27.
            /// </summary>
            /// <value>The color 27.</value>
            [JsonProperty("COLOR_27")] public string COLOR_27 { get; set; }
            /// <summary>
            /// Gets or sets the color 28.
            /// </summary>
            /// <value>The color 28.</value>
            [JsonProperty("COLOR_28")] public string COLOR_28 { get; set; }
            /// <summary>
            /// Gets or sets the color 29.
            /// </summary>
            /// <value>The color 29.</value>
            [JsonProperty("COLOR_29")] public string COLOR_29 { get; set; }
            /// <summary>
            /// Gets or sets the color 30.
            /// </summary>
            /// <value>The color 30.</value>
            [JsonProperty("COLOR_30")] public string COLOR_30 { get; set; }
            /// <summary>
            /// Gets or sets the color 31.
            /// </summary>
            /// <value>The color 31.</value>
            [JsonProperty("COLOR_31")] public string COLOR_31 { get; set; }
            /// <summary>
            /// Gets or sets the color 32.
            /// </summary>
            /// <value>The color 32.</value>
            [JsonProperty("COLOR_32")] public string COLOR_32 { get; set; }
            /// <summary>
            /// Gets or sets the color 33.
            /// </summary>
            /// <value>The color 33.</value>
            [JsonProperty("COLOR_33")] public string COLOR_33 { get; set; }
            /// <summary>
            /// Gets or sets the color 34.
            /// </summary>
            /// <value>The color 34.</value>
            [JsonProperty("COLOR_34")] public string COLOR_34 { get; set; }
            /// <summary>
            /// Gets or sets the color 35.
            /// </summary>
            /// <value>The color 35.</value>
            [JsonProperty("COLOR_35")] public string COLOR_35 { get; set; }
            /// <summary>
            /// Gets or sets the color 36.
            /// </summary>
            /// <value>The color 36.</value>
            [JsonProperty("COLOR_36")] public string COLOR_36 { get; set; }
        }

        /// <summary>
        /// Class StatsData.
        /// </summary>
        public class StatsData
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            [JsonProperty("Id")]
            public string Id { get; set; }

            /// <summary>
            /// Gets or sets the grouped by.
            /// </summary>
            /// <value>The grouped by.</value>
            [JsonProperty("Label")]
            public string GroupedBy { get; set; }

            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            /// <value>The data.</value>
            [JsonProperty("Data")]
            public StatsLine[] Data { get; set; }
        }

        /// <summary>
        /// Class StatsLine.
        /// </summary>
        public class StatsLine
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public string Id { get; set; }

            /// <summary>
            /// Gets or sets the type.
            /// </summary>
            /// <value>The type.</value>
            [JsonProperty("Label")]
            public string Type { get; set; }

            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            /// <value>The data.</value>
            public Data Data { get; set; }
        }

        /// <summary>
        /// Class Data.
        /// </summary>
        public class Data
        {
            /// <summary>
            /// Gets or sets the sum.
            /// </summary>
            /// <value>The sum.</value>
            [JsonProperty("sum")]
            public decimal sum { get; set; }

            /// <summary>
            /// Gets or sets the costs
            /// </summary>
            /// <value>The CST.</value>
            [JsonProperty("cst")]
            public decimal cst { get; set; }

            /// <summary>
            /// Gets or sets the number of transactions
            /// </summary>
            /// <value>The number.</value>
            [JsonProperty("num")]
            public decimal num { get; set; }

            /// <summary>
            /// Gets or sets the average duration.  Probably the average duration of seconds in a transaction.
            /// </summary>
            /// <value>The average dur.</value>
            [JsonProperty("avg_dur")]
            public decimal avg_dur { get; set; }

            /// <summary>
            /// Gets or sets the average payout amount
            /// </summary>
            /// <value>The average pay.</value>
            [JsonProperty("avg_pay")]
            public decimal avg_pay { get; set; }

            /// <summary>
            /// Gets or sets the paid costs. <seealso cref="cst"/>
            /// </summary>
            /// <value>The pay.</value>
            [JsonProperty("pay")]
            public decimal pay { get; set; }

            /// <summary>
            /// Gets or sets the organization total.  Same as org_tot
            /// </summary>
            /// <value>The org.</value>
            [JsonProperty("org")]
            public string org { get; set; }

            /// <summary>
            /// Gets or sets the org vat.
            /// </summary>
            /// <value>The org vat.</value>
            [JsonProperty("org_vat")]
            public string org_vat { get; set; }

            /// <summary>
            /// Gets or sets the org ext.
            /// </summary>
            /// <value>The org ext.</value>
            [JsonProperty("org_ext")]
            public string org_ext { get; set; }

            /// <summary>
            /// Gets or sets the org tot.
            /// </summary>
            /// <value>The org tot.</value>
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
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(decimal?);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            switch (token.Type)
            {
                case JTokenType.Float:
                case JTokenType.Integer:
                    return token.ToObject<decimal>();
                case JTokenType.String when decimal.TryParse(
                    token.ToString(),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out var d):
                    return d;
                case JTokenType.String:
                case JTokenType.Null when objectType == typeof(decimal?):
                    return null;
                default:
                    throw new JsonSerializationException($"Unexpected token type: {token.Type}");
            }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var d = default(decimal?);
            if (value != null)
            {
                d = value as decimal?;
                if (d.HasValue) // If value was a decimal?, then this is possible
                {
                    d = new decimal(
                        decimal.ToDouble(d.Value)); // The ToDouble-conversion removes all unnecessary precision
                }
            }

            JToken.FromObject(d).WriteTo(writer);
        }
    }
}
