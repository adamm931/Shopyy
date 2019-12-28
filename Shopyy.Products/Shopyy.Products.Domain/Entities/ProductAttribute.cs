using Shopyy.Common.Guard;
using Shopyy.Domain;
using System;

namespace Shopyy.Products.Domain.Entities
{
    public class ProductAttribute : IEntity<Guid>
    {
        public ProductAttribute(string name, string value)
        {
            Ensure.NotEmpty(name, nameof(name));
            Ensure.NotEmpty(value, nameof(value));

            Id = Guid.NewGuid();

            Name = name;
            Value = value;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public ProductVariant Variant { get; private set; }

        public Guid VariantId { get; private set; }
    }
}
