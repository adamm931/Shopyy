using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Seed
{
    public interface ISeeder
    {
        Task SeedAsync();
    }
}
