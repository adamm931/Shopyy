using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopyy.Infrastructure.Common;
using Shopyy.Infrastructure.Extensions;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Infrastructure.Common;

namespace Shopyy.Products.Infrastructure.Configurations
{
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable(Tables.ProductAttributes)
                .Column(model => model.Id, CommonColumns.Id)
                .Column(model => model.Name, CommonColumns.Name)
                .Column(model => model.Value, Columns.ProductAttribute.Value)
                .Column(model => model.VariantId, Columns.ProductAttribute.VariantId);

            builder.Property(model => model.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(model => model.Value)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(model => model.Variant)
                .WithMany(variant => variant.Attributes)
                .HasForeignKey(attribute => attribute.VariantId);
        }
    }
}
