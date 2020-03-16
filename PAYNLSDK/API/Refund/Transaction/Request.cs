using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace PAYNLSDK.API.Refund.Transaction
{
    /// <summary>
    /// A product specific refund for Products like Sofort & Afterpay
    /// For normal refunds, you should use <seealso cref="PAYNLSDK.API.Transaction.Refund.Request"/>
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// </summary>
        /// <param name="transactionId">The order ID or EX code of the transaction</param>
        public Request(string transactionId)
        {
            TransactionId = transactionId;
            Products = new Dictionary<string, int>();
        }

        /// <summary>
        /// The order ID or EX code of the transaction.
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The amount to be paid should be given in cents. For example € 3.50 becomes 350.
        /// </summary>
        [JsonProperty("amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// The description to include with the payment.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The description to include with the payment.
        /// </summary>
        [JsonProperty("processDate"), JsonConverter(typeof(DMYConverter))]
        public DateTime? ProcessDate { get; set; }

        /// <summary>
        /// Custom exchange URL overriding the defaultexchange URL.
        /// </summary>
        [JsonProperty("exchangeUrl")]
        public string ExchangeUrl { get; set; }

        /// <summary>
        /// Product items that are refunded (key: product ID, value: quantity).
        /// </summary>
        [JsonProperty("products")]
        public Dictionary<string, int> Products { get; set; }

        /// <summary>
        /// Add a product reference (key + amount)
        /// </summary>
        /// <param name="productId">The order ID or EX code of the transaction</param>
        /// <param name="amount">Product quantity</param>
        public void AddProduct(string productId, int amount)
        {
            if (Products.ContainsKey(productId))
            {
                Products[productId] += amount;
            }
            else
            {
                Products[productId] = amount;
            }
        }

        /// <inheritdoc />
        protected override int Version => 2;

        /// <inheritdoc />

        protected override string Controller => "Refund";

        /// <inheritdoc />
        protected override string Method => "transaction";

        //public override string Querystring
        //{
        //    get { return ""; }
        //}

        /// <inheritdoc />
        public override bool RequiresApiToken => true;

        /// <inheritdoc />
        public override bool RequiresServiceId => true;

        /// <inheritdoc />
        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = new NameValueCollection();

            ParameterValidator.IsNotNull(TransactionId, "TransactionId");
            nvc.Add("transactionId", TransactionId.ToString());

            if (ParameterValidator.IsNonEmptyInt(Amount))
            {
                nvc.Add("amount", Amount.Value.ToString());
            }

            if (!ParameterValidator.IsEmpty(Description))
            {
                nvc.Add("description", Description);
            }

            if (ProcessDate.HasValue)
            {
                nvc.Add("processDate", ProcessDate.Value.ToString("yyyy-MM-dd"));
            }

            if (Products.Count > 0)
            {
                nvc.Add("products", JsonConvert.SerializeObject(Products));
            }

            if (!ParameterValidator.IsEmpty(ExchangeUrl))
            {
                nvc.Add("exchangeUrl", ExchangeUrl);
            }

            return nvc;
        }

        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
            if (!Response.Request.Result)
            {
                // toss
                throw new PayNlException(Response.Request.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Response Response => (Response)response;

        private static Dictionary<string, object> NvcToDictionary(NameValueCollection nvc, bool handleMultipleValuesPerKey)
        {
            var result = new Dictionary<string, object>();
            foreach (string key in nvc.Keys)
            {
                if (handleMultipleValuesPerKey)
                {
                    string[] values = nvc.GetValues(key);
                    if (values.Length == 1)
                    {
                        result.Add(key, values[0]);
                    }
                    else
                    {
                        result.Add(key, values);
                    }
                }
                else
                {
                    result.Add(key, nvc[key]);
                }
            }

            return result;
        }
    }
}
