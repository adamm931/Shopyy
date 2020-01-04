using Shopyy.Common.Guard;
using Shopyy.Domain;
using System;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.Entities
{
    public class Product : IEntity<Guid>
    {
        private List<ProductVariant> _variants;

        public Product(string name, string description)
        {
            Ensure.NotEmpty(name, nameof(name));

            Id = Guid.NewGuid();

            Name = name;
            Description = description;

            _variants = new List<ProductVariant>();
        }

        private Product()
        {
        }

        public Guid Id { get; private set; }

        public long SerialNumber { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<ProductVariant> Variants
        {
            get => _variants.AsReadOnly();
            set { }
        }

        public void AddVariant(ProductVariant variant)
        {
            _variants.Add(variant);
        }

        public Product AddVariants(IEnumerable<ProductVariant> variants)
        {
            _variants.AddRange(variants);

            return this;
        }
    }
}
