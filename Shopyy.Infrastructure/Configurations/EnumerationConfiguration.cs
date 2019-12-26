using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopyy.Common.Guard;
using Shopyy.Domain;
using Shopyy.Infrastructure.Common;
using Shopyy.Infrastructure.Extensions;

namespace Shopyy.Infrastructure.Configurations
{
    public abstract class EnumerationConfiguration<TEnumEntity, TEnum> : IEntityTypeConfiguration<TEnumEntity>
        where TEnumEntity : EnumEntity<TEnum>
        where TEnum : struct
    {
        private readonly string _enumerationTable;

        public EnumerationConfiguration(string enumerationTable)
        {
            Ensure.NotEmpty(enumerationTable, nameof(enumerationTable));

            _enumerationTable = enumerationTable;
        }

        public void Configure(EntityTypeBuilder<TEnumEntity> builder)
        {
            builder.ToTable(_enumerationTable);

            builder
                .Column(model => model.Id, CommonColumns.Id)
                .Column(model => model.Name, CommonColumns.Name);

            builder
                .Property(model => model.Name)
                .IsRequired();

            builder.Property(model => model.Id)
                .HasConversion(new EnumToNumberConverter<TEnum, int>());

        }
    }
}
