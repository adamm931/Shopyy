using Shopyy.Common.Guard;
using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Factories.Products;
using Shopyy.Products.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public ColorTypeId Color => GetAttribute<ColorProductAttribute>().ColorTypeId;

        public BrandTypeId Brand => GetAttribute<BrandProductAttribute>().BrandTypeId;

        public SizeTypeId Size => GetAttribute<SizeProductAttribute>().SizeTypeId;

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

        public void IncreaseStockCount() => StockCount += 1;

        private TAttribute GetAttribute<TAttribute>() where TAttribute : ProductAttribute
            => Attributes
                .OfType<TAttribute>()
                .Single();
    }
}
