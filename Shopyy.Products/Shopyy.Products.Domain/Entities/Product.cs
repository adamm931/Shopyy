using Shopyy.Common.Guard;
using Shopyy.Domain;
using System;
using System.Collections.Generic;

namespace Shopyy.Products.Domain.Entities
{
    public class Product : IEntity<Guid>
    {
        private List<ProductVariant> _variants;

        public Product(
            string articleNumber,
            string name,
            string description
            )
        {
            Ensure.NotEmpty(articleNumber, nameof(articleNumber));
            Ensure.NotEmpty(name, nameof(name));

            Id = Guid.NewGuid();

            ArticleNumber = articleNumber;
            Name = name;
            Description = description;

            _variants = new List<ProductVariant>();
        }

        private Product()
        {
        }

        public Guid Id { get; private set; }

        public long SerialNumber { get; private set; }

        public string ArticleNumber { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<ProductVariant> Variants
        {
            get => _variants.AsReadOnly();
            set { }
        }

        public Product AddVariants(params ProductVariant[] variants)
        {
            _variants.AddRange(variants);

            return this;
        }
    }
}
