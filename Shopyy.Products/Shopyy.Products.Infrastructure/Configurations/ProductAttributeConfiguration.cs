using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopyy.Infrastructure.Common;
using Shopyy.Infrastructure.Extensions;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Infrastructure.Common;

namespace Shopyy.Products.Infrastructure.Configurations
{
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable(Tables.ProductAttributes)
                .Column(model => model.Id, CommonColumns.Id)
                .Column(model => model.AttributeTypeId, Columns.ProductAttribute.AttributeTypeId)
                .Column(model => model.VariantId, Columns.ProductAttribute.VariantId);

            builder.HasOne(model => model.Variant)
                .WithMany(variant => variant.Attributes)
                .HasForeignKey(attribute => attribute.VariantId);

            builder.HasOne(model => model.AttributeType)
                .WithMany(variant => variant.Attributes)
                .HasForeignKey(attribute => attribute.AttributeTypeId);

            builder.HasDiscriminator(model => model.AttributeTypeId)
                .HasValue<ColorProductAttribute>(ProductAttributeTypeId.Color)
                .HasValue<SizeProductAttribute>(ProductAttributeTypeId.Size)
                .HasValue<BrandProductAttribute>(ProductAttributeTypeId.Brand);
        }
    }

    public class ColorAttributeConfiguration : IEntityTypeConfiguration<ColorProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ColorProductAttribute> builder)
        {
            builder.HasBaseType<ProductAttribute>();

            builder.Column(model => model.ColorTypeId, Columns.ProductAttribute.Color.TypeId);

            builder.HasOne(model => model.ColorType)
                .WithMany(color => color.Attributes)
                .HasForeignKey(model => model.ColorTypeId);
        }
    }

    public class BrandAttributeConfiguration : IEntityTypeConfiguration<BrandProductAttribute>
    {
        public void Configure(EntityTypeBuilder<BrandProductAttribute> builder)
        {
            builder.HasBaseType<ProductAttribute>();

            builder.Column(model => model.BrandTypeId, Columns.ProductAttribute.Brand.TypeId);

            builder.HasOne(model => model.BrandType)
                .WithMany(color => color.Attributes)
                .HasForeignKey(model => model.BrandTypeId);
        }
    }

    public class SizeAttributeConfiguration : IEntityTypeConfiguration<SizeProductAttribute>
    {
        public void Configure(EntityTypeBuilder<SizeProductAttribute> builder)
        {
            builder.HasBaseType<ProductAttribute>();

            builder.Column(model => model.SizeTypeId, Columns.ProductAttribute.Size.TypeId);

            builder.HasOne(model => model.SizeType)
                .WithMany(color => color.Attributes)
                .HasForeignKey(model => model.SizeTypeId);
        }
    }
}
