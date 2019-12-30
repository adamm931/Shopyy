using Shopyy.Common.Guard;
using Shopyy.Domain;
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

        public string Sku { get; private set; }

        public decimal Price { get; private set; }

        public int StockCount { get; private set; }

        public IReadOnlyCollection<ProductAttribute> Attributes
        {
            get => _attributes.AsReadOnly();
            set { }
        }

        public decimal GetPriceForCurrency(Currency currency)
        {
            return Price * currency.Factor;
        }

        public ProductVariant AddAttributes(IEnumerable<ProductAttribute> attributes)
        {
            _attributes.AddRange(attributes);

            return this;
        }
    }
}
