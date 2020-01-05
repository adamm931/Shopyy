using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopyy.Infrastructure.Extensions;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Infrastructure.Common;
using CommonColumns = Shopyy.Infrastructure.Common.CommonColumns;


namespace Shopyy.Products.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(Tables.Products)
                .Column(model => model.Id, CommonColumns.Id)
                .Column(model => model.Name, CommonColumns.Name)
                .Column(model => model.SerialNumber, Columns.Product.SerialNumber)
                .Column(model => model.Description, Columns.Product.Description);

            builder.Property(model => model.SerialNumber)
                .HasDefaultValueSql($"nextval('{Sequnces.ProductSerialNumber}')")
                .IsRequired();

            builder.HasIndex(model => model.SerialNumber)
                .IsUnique();

            builder.HasIndex(model => model.Name)
                .IsUnique();

            builder.Property(model => model.Name)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
