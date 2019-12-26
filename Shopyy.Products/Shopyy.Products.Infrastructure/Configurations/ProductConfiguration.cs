﻿using Microsoft.EntityFrameworkCore;
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
            builder.ToTable(Tables.Products);

            builder
                .Column(model => model.Id, CommonColumns.Id)
                .Column(model => model.Name, CommonColumns.Name)
                .Column(model => model.SerialNumber, Columns.Product.SerialNumber)
                .Column(model => model.ArticleNumber, Columns.Product.ArticleNumber)
                .Column(model => model.Price, Columns.Product.Price)
                .Column(model => model.Description, Columns.Product.Description)
                .Column(model => model.StockCount, Columns.Product.StockCount);

            builder.Property(model => model.SerialNumber)
                .HasDefaultValueSql($"nextval('{Sequnces.ProductSerialNumber}')")
                .IsRequired();

            builder.HasIndex(model => model.SerialNumber)
                .IsUnique();

            builder.Property(model => model.ArticleNumber)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(model => model.ArticleNumber)
                .IsUnique();

            builder.Property(model => model.Name)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
