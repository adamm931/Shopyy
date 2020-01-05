using Shopyy.Common.Guard;
using Shopyy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddVariantOrIncreaseStockCount(ProductVariant variant)
        {
            var variantBySku = _variants
                .SingleOrDefault(varr => varr.Sku == variant.Sku);

            if (variantBySku == null)
            {
                _variants.Add(variant);
            }

            else
            {
                variantBySku.IncreaseStockCount();
            }
        }

        public Product AddVariants(IEnumerable<ProductVariant> variants)
        {
            _variants.AddRange(variants);

            return this;
        }
    }
}
