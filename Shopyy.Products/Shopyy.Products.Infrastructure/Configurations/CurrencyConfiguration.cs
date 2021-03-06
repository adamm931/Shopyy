﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopyy.Infrastructure.Extensions;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Infrastructure.Common;
using CommonColumns = Shopyy.Infrastructure.Common.CommonColumns;


namespace Shopyy.Products.Infrastructure.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable(Tables.Currencies);

            builder
                .Column(model => model.Id, CommonColumns.Id)
                .Column(model => model.Description, Columns.Currency.Description)
                .Column(model => model.Factor, Columns.Currency.Factor)
                .Column(model => model.CurrnecyCodeTypeId, Columns.Currency.CurrencyCodeId);

            builder.HasOne(model => model.CurrencyCode)
                .WithMany(code => code.Currencies)
                .HasForeignKey(model => model.CurrnecyCodeTypeId);
        }
    }
}
