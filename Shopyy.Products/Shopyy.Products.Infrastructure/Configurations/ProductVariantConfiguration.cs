using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopyy.Infrastructure.Common;
using Shopyy.Infrastructure.Extensions;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Infrastructure.Common;

namespace Shopyy.Products.Infrastructure.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable(Tables.ProductVariants)
                .Column(model => model.Id, CommonColumns.Id)
                .Column(model => model.Price, Columns.ProductVariant.Price)
                .Column(model => model.StockCount, Columns.ProductVariant.StockCount)
                .Column(model => model.ProductId, Columns.ProductVariant.ProductId);

            builder.HasOne(model => model.Product)
                .WithMany(product => product.Variants)
                .HasForeignKey(model => model.ProductId);
        }
    }
}
