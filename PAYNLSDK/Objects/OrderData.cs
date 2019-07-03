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
        /// Type of the order line. Possible values: ARTICLE, SHIPPING, HANDLING, DISCOUNT
        /// </summary>
        [JsonProperty("productType"), JsonConverter(typeof(ProductTypeConverter))]
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="quantity">Quantity of products with this product id</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, string vatCode, int quantity, string productType)
        {
            ProductId = productId;
            Description = description;
            Price = price;
            Quantity = quantity;
            VatCode = VatCode = EnumUtil.ToEnum<TaxClass>(vatCode);
            ProductType = EnumUtil.ToEnum<ProductType>(productType);
        }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="quantity">Quantity of products with this product id</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, string vatCode, int quantity, ProductType productType)
        {
            ProductId = productId;
            Description = description;
            Price = price;
            Quantity = quantity;
            VatCode = VatCode = EnumUtil.ToEnum<TaxClass>(vatCode);
            ProductType = productType;
        }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, string vatCode, string productType) : this(productId, description, price, vatCode, 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, int price, string vatCode, string productType) : this(productId, "", price, vatCode, 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, string productType) : this(productId, description, price, "N", 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, int price, string productType) : this(productId, "", price, "N", 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, string vatCode, ProductType productType) : this(productId, description, price, vatCode, 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, int price, string vatCode, ProductType productType) : this(productId, "", price, vatCode, 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, ProductType productType) : this(productId, description, price, "N", 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, int price, ProductType productType) : this(productId, "", price, "N", 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="quantity">Quantity of products with this product id</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, TaxClass vatCode, int quantity, string productType)
        {
            ProductId = productId;
            Description = description;
            Price = price;
            Quantity = quantity;
            VatCode = vatCode;
            //VatCode = EnumUtil.ToEnumString<TaxClass>((TaxClass)vatCode);
            //VatCode = EnumUtil.ToEnum<TaxClass>(vatCode);
            ProductType = EnumUtil.ToEnum<ProductType>(productType);
        }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="quantity">Quantity of products with this product id</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, TaxClass vatCode, int quantity, ProductType productType)
        {
            ProductId = productId;
            Description = description;
            Price = price;
            Quantity = quantity;
            VatCode = vatCode;
            //VatCode = EnumUtil.ToEnumString<TaxClass>((TaxClass)vatCode);
            //VatCode = EnumUtil.ToEnum<TaxClass>(vatCode);
            ProductType = productType;
        }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, TaxClass vatCode, string productType) : this(productId, description, price, vatCode, 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, int price, TaxClass vatCode, string productType) : this(productId, "", price, vatCode, 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        public OrderData(string productId, int price, TaxClass vatCode) : this(productId, "", price, vatCode, 1, ProductType.ARTICLE) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="description">Description of the product (max 45 characters)</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, string description, int price, TaxClass vatCode, ProductType productType) : this(productId, description, price, vatCode, 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        /// <param name="productType">Product Type</param>
        public OrderData(string productId, int price, TaxClass vatCode, ProductType productType) : this(productId, "", price, vatCode, 1, productType) { }

        /// <summary>
        /// Create a new OrderData specification
        /// </summary>
        /// <param name="productId">Your systems product ID</param>
        /// <param name="price">Amount in cents of the product (amount incl. vat)</param>
        /// <param name="vatCode">The vat code</param>
        public OrderData(string productId, int price, TaxClass vatCode) : this(productId, "", price, vatCode, 1, ProductType.ARTICLE) { }

    }
}
