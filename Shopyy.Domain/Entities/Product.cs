using Shopyy.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Shopyy.Domain.Entities
{
    public class Product : IEntity, IAggregateRoot
    {
        private readonly List<ProductPrice> productPrices;

        public Product(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;

            productPrices = new List<ProductPrice>();
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyCollection<ProductPrice> Prices
        {
            get => productPrices.AsReadOnly();
            private set { }
        }

        public void AddPrice(decimal amount, string currencyCode)
        {
            var productPrice = new ProductPrice(amount, currencyCode);

            productPrices.Add(productPrice);
        }

        public void RemovePriceForCurrency(string currencyCode)
        {
            productPrices.RemoveAll(price => price.HasCurrency(currencyCode));
        }
    }
}
