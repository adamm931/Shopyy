using Shopyy.Common.Guard;
using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using System;

namespace Shopyy.Products.Domain.Entities
{
    public abstract class ProductAttribute : IEntity<Guid>
    {
        protected ProductAttribute(ProductAttributeTypeId attributeTypeId, string value)
        {
            Ensure.EnumValueDefined(attributeTypeId, nameof(attributeTypeId));
            Ensure.NotEmpty(value, nameof(value));

            Id = Guid.NewGuid();

            AttributeTypeId = attributeTypeId;
            Value = value;
        }

        protected ProductAttribute()
        {
        }

        public Guid Id { get; private set; }

        public string Value { get; private set; }

        public ProductVariant Variant { get; private set; }

        public Guid VariantId { get; private set; }

        public ProductAttributeType AttributeType { get; private set; }

        public ProductAttributeTypeId AttributeTypeId { get; private set; }
    }

    public class ColorProductAttribute : ProductAttribute
    {
        public ColorProductAttribute(string value) : base(ProductAttributeTypeId.Color, value)
        {
        }
    }

    public class BrandProductAttribute : ProductAttribute
    {
        public BrandProductAttribute(string value) : base(ProductAttributeTypeId.Brand, value)
        {
        }
    }

    public class SizeProductAttribute : ProductAttribute
    {
        public SizeProductAttribute(string value) : base(ProductAttributeTypeId.Size, value)
        {
        }
    }
}
