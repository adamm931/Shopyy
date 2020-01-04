using Shopyy.Common.Guard;
using Shopyy.Domain;
using Shopyy.Products.Domain.Enumerations;
using System;

namespace Shopyy.Products.Domain.Entities
{
    public abstract class ProductAttribute : IEntity<Guid>
    {
        protected ProductAttribute(ProductAttributeTypeId attributeTypeId)
        {
            Ensure.EnumValueDefined(attributeTypeId, nameof(attributeTypeId));

            Id = Guid.NewGuid();

            AttributeTypeId = attributeTypeId;
        }

        protected ProductAttribute()
        {
        }

        public Guid Id { get; private set; }

        public ProductVariant Variant { get; private set; }

        public Guid VariantId { get; private set; }

        public ProductAttributeType AttributeType { get; private set; }

        public ProductAttributeTypeId AttributeTypeId { get; private set; }

        public abstract string ShortName { get; }
    }

    public class ColorProductAttribute : ProductAttribute
    {
        public ColorProductAttribute(ColorTypeId color) : base(ProductAttributeTypeId.Color)
        {
            ColorTypeId = color;
        }

        private ColorProductAttribute()
        { }

        public ColorType ColorType { get; private set; }

        public ColorTypeId ColorTypeId { get; private set; }

        public override string ShortName => ColorTypeId.ToShortName();
    }

    public class BrandProductAttribute : ProductAttribute
    {
        public BrandProductAttribute(BrandTypeId brand) : base(ProductAttributeTypeId.Brand)
        {
            BrandTypeId = brand;
        }

        private BrandProductAttribute()
        { }

        public BrandType BrandType { get; private set; }

        public BrandTypeId BrandTypeId { get; private set; }

        public override string ShortName => BrandTypeId.ToShortName();
    }

    public class SizeProductAttribute : ProductAttribute
    {
        public SizeProductAttribute(SizeTypeId size) : base(ProductAttributeTypeId.Size)
        {
            SizeTypeId = size;
        }

        private SizeProductAttribute()
        { }

        public SizeType SizeType { get; private set; }

        public SizeTypeId SizeTypeId { get; private set; }

        public override string ShortName => SizeTypeId.ToShortName();
    }
}
