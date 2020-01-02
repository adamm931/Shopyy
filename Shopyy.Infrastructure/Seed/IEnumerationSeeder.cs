using Shopyy.Domain;

namespace Shopyy.Infrastructure.Seed
{
    public interface IEnumerationSeeder<TEnumEntity, TEnum>
        where TEnumEntity : EnumEntity<TEnum>
        where TEnum : struct
    {
        void SeedEnumeration();
    }

    public interface IEnumerationsSeeder
    {
        void SeedEnumerations();
    }
}
