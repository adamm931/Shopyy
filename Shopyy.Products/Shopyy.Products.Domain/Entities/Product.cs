using Shopyy.Common.Guard;
using Shopyy.Domain;
using System;

namespace Shopyy.Products.Domain.Entities
{
    public class Product : IEntity<Guid>
    {
        public Product(
            string articleNumber,
            string name,
            string description,
            decimal price,
            int stockCount
            )
        {
            Ensure.NotEmpty(articleNumber, nameof(articleNumber));
            Ensure.NotEmpty(name, nameof(name));
            Ensure.NonNegative(price, nameof(price));
            Ensure.NonNegative(stockCount, nameof(stockCount));

            Id = Guid.NewGuid();

            ArticleNumber = articleNumber;
            Name = name;
            Description = description;
            Price = price;
            StockCount = stockCount;
        }

        private Product()
        {
        }

        public Guid Id { get; private set; }

        public long SerialNumber { get; private set; }

        public string ArticleNumber { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int StockCount { get; private set; }

        public decimal GetPriceForCurrency(Currency currency)
        {
            return Price * currency.Factor;
        }
    }
}
