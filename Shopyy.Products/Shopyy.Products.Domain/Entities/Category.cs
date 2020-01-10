using Shopyy.Common.Guard;
using Shopyy.Domain;
using Shopyy.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopyy.Products.Domain.Entities
{
    public class Category : IEntity, IAgreegateRoot
    {
        private readonly List<Product> _products;

        public Category(string name, string description)
        {
            Id = Guid.NewGuid();

            SetName(name);
            SetDescription(description);

            _products = new List<Product>();
        }

        private Category()
        {
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public void Update(string name, string description)
        {
            SetName(name);
            SetDescription(description);
        }

        public Product AddProduct(string name, string description)
        {
            var product = new Product(name, description);

            _products.Add(product);

            return product;
        }

        public Product GetProduct(Guid id) =>
            _products.SingleOrDefault(product => product.Id == id) ?? throw new EntityNotFoundException<Product>(id);

        public void RemoveProduct(Guid id)
            => _products.RemoveAll(product => product.Id == id);

        private void SetName(string name)
        {
            Ensure.NotEmpty(name, nameof(name));

            Name = name;
        }

        private void SetDescription(string description)
             => Description = description;
    }
}
