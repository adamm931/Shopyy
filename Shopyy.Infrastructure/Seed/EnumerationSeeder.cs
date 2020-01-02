using Shopyy.Domain;
using Shopyy.Infrastructure.Postgres;
using System;
using System.Collections.Generic;

namespace Shopyy.Infrastructure.Seed
{
    public class EnumerationSeeder<TEnumEntity, TEnum> : IEnumerationSeeder<TEnumEntity, TEnum>
        where TEnumEntity : EnumEntity<TEnum>
        where TEnum : struct
    {
        private readonly IDbTableProvider _tableProvider;

        public EnumerationSeeder(IDbTableProvider tableProvider)
        {
            _tableProvider = tableProvider;
        }

        public void SeedEnumeration()
        {
            _tableProvider
                .Table<TEnum, TEnumEntity>()
                .AddRange(GetEnumRecords());
        }

        private IEnumerable<TEnumEntity> GetEnumRecords()
        {
            foreach (var value in Enum.GetValues(typeof(TEnum)))
            {
                yield return Activator.CreateInstance(typeof(TEnumEntity), value) as TEnumEntity;
            }
        }
    }
}
