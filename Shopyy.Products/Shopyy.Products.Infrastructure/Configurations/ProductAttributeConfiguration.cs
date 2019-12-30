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
                .Column(model => model.Value, Columns.ProductAttribute.Value)
                .Column(model => model.VariantId, Columns.ProductAttribute.VariantId);

            builder.Property(model => model.Value)
                .IsRequired()
                .HasMaxLength(100);

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
}
