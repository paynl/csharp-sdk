using System;
using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Enums;

namespace PAYNLSDK.Objects
{
    /// <summary>
    /// Ordered product information
    /// </summary>
    public class OrderData
    {
        /// <summary>
        /// Your systems product ID
        /// </summary>
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        /// <summary>
        /// Description of the product (max 45 characters)
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Amount in cents of the product (amount incl. vat)
        /// </summary>
        [JsonProperty("price")]
        public int Price { get; set; }

        /// <summary>
        /// Quantity of products with this product id
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The vat code
        /// </summary>
        [JsonProperty("vatCode"),JsonConverter(typeof(TaxClassConverter))]
        public TaxClass VatCode { get; set; }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="quantity">Quantity of products with this product id</param>
        public OrderData(string productId, string description, int price, string vatCode, int quantity)
        {
            ProductId = productId;
            Description = description;
            Price = price;
            Quantity = quantity;
            VatCode = VatCode = EnumUtil.ToEnum<TaxClass>(vatCode);
        }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        public OrderData(string productId, string description, int price, string vatCode) : this(productId, description, price, vatCode, 1) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        public OrderData(string productId, int price, string vatCode) : this(productId, "", price, vatCode, 1) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        public OrderData(string productId, string description, int price) : this(productId, description, price, "N", 1) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        public OrderData(string productId, int price) : this(productId, "", price, "N", 1) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="quantity">Quantity of products with this product id</param>
        public OrderData(string productId, string description, int price, TaxClass vatCode, int quantity)
        {
            ProductId = productId;
            Description = description;
            Price = price;
            Quantity = quantity;
            VatCode = vatCode;
            //VatCode = EnumUtil.ToEnumString<TaxClass>((TaxClass)vatCode);
            //VatCode = EnumUtil.ToEnum<TaxClass>(vatCode);
        }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        public OrderData(string productId, string description, int price, TaxClass vatCode) : this(productId, description, price, vatCode, 1) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        public OrderData(string productId, int price, TaxClass vatCode) : this(productId, "", price, vatCode, 1) { }

    }
}
