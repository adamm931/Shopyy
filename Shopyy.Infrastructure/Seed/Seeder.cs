using Shopyy.Application.Abstractions.Repository;
using Shopyy.Infrastructure.Mongo;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Seed
{
    public class Seeder : ISeeder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMongoDatabaseProvider _databaseProvider;

        public Seeder(
            IUnitOfWork unitOfWork,
            IMongoDatabaseProvider databaseProvider)
        {
            _unitOfWork = unitOfWork;
            _databaseProvider = databaseProvider;
        }

        public async Task SeedAsync()
        {
            if (_databaseProvider.IsCreated)
            {
                return;
            }

            var products = SeederData.GetProducts();

            _unitOfWork.Products.AddRange(products);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
