using Shopyy.Common.Guard;
using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Factories.Products;
using Shopyy.Products.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.Entities
{
    public class ProductVariant : IEntity<Guid>
    {
        private readonly List<ProductAttribute> _attributes;

        public ProductVariant(decimal price, int stockCount)
        {
            Id = Guid.NewGuid();

            Ensure.NonNegative(price, nameof(price));
            Ensure.NonNegative(stockCount, nameof(stockCount));

            Price = price;
            StockCount = stockCount;

            _attributes = new List<ProductAttribute>();
        }

        public Guid Id { get; private set; }

        public Product Product { get; private set; }

        public Guid ProductId { get; private set; }

        public Sku Sku { get; private set; }

        public decimal Price { get; private set; }

        public int StockCount { get; private set; }

        public IReadOnlyCollection<ProductAttribute> Attributes
        {
            get => _attributes.AsReadOnly();
            set { }
        }

        public string ProductName => Product.Name;

        public ProductVariant SetSku(Sku sku)
        {
            Sku = sku;
            return this;
        }

        public decimal GetPriceForCurrency(Currency currency)
        {
            return Price * currency.Factor;
        }

        public ProductVariant AddColor(ColorTypeId color)
        {
            _attributes.Add(ProductAttributeBuilder.New
                .ForColor()
                .HasValue(color)
                .Build());

            return this;
        }

        public ProductVariant AddBrand(BrandTypeId brand)
        {
            _attributes.Add(ProductAttributeBuilder.New
               .ForBrand()
               .HasValue(brand)
               .Build());

            return this;
        }

        public ProductVariant AddSize(SizeTypeId size)
        {
            _attributes.Add(ProductAttributeBuilder.New
               .ForSize()
               .HasValue(size)
               .Build());

            return this;
        }

        //public ProductVariant AddAttributes(IEnumerable<(ProductAttributeTypeId Type, Enum Value)> attributesData)
        //{
        //    foreach (var attributeData in attributesData)
        //    {
        //        var builder = attributeData.Type switch
        //        {
        //            ProductAttributeTypeId.Brand => ProductAttributeBuilder.New
        //                .ForBrand()
        //                .HasValue(attributeData.Value),

        //            ProductAttributeTypeId.Color => ProductAttributeBuilder.New
        //                .ForColor()
        //                .HasValue(attributeData.Value),

        //            ProductAttributeTypeId.Size => ProductAttributeBuilder.New
        //                .ForSize()
        //                .HasValue(attributeData.Value),

        //            _ => null
        //        };

        //        var attribute = builder.Build();

        //        _attributes.Add(attribute);
        //    }

        //    return this;
        //}
    }
}
