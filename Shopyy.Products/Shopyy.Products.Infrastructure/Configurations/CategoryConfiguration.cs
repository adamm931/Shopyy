using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopyy.Infrastructure.Common;
using Shopyy.Infrastructure.Extensions;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopyy.Products.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(Tables.Categories)
                .Column(model => model.Id, CommonColumns.Id)
                .Column(model => model.Name, CommonColumns.Name)
                .Column(model => model.Description, CommonColumns.Description);

            builder.HasMany(category => category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId);
        }
    }
}
