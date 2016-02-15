using System;
using Newtonsoft.Json;

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
        [JsonProperty("vatCode")]
        public string VatCode { get; set; }

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
            VatCode = vatCode;
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

    }
}
