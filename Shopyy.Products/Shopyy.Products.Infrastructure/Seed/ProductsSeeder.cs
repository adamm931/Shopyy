using Microsoft.Extensions.Options;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Infrastructure.Interfaces;
using Shopyy.Infrastructure.Options;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Interfacaes;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Seed
{
    public class ProductsSeeder : ISeeder
    {
        private readonly IDatabaseCreator _databaseCreator;
        private readonly IEnumerationsSeeder _enumerationsSeeder;
        private readonly IOptions<SeedOptions> _seedOptions;
        private readonly ISkuProvider _skuProvider;

        private readonly IRepository<Category> _categories;
        private readonly IRepository<Currency> _currencies;

        public ProductsSeeder(
            IDatabaseCreator databaseInitializer,
            IEnumerationsSeeder enumerationsSeeder,
            IOptions<SeedOptions> seedOptions,
            ISkuProvider skuProvider,

            IRepository<Category> categories,
            IRepository<Currency> currencies
            )
        {
            _databaseCreator = databaseInitializer;
            _enumerationsSeeder = enumerationsSeeder;
            _seedOptions = seedOptions;
            _skuProvider = skuProvider;

            _categories = categories;
            _currencies = currencies;
        }

        public async Task SeedAsync()
        {
            var recreate = _seedOptions.Value.Recreate;
            var isCreated = await _databaseCreator.CreateAsync(recreate);

            if (!isCreated)
            {
                return;
            }

            var unitOfWork = _categories.UnitOfWork;

            _categories.AddRange(SeederData.GetCategoriesWithProducts(_skuProvider));
            _currencies.AddRange(SeederData.GetCurrencies());

            _enumerationsSeeder.SeedEnumerations();

            await unitOfWork.SaveAsync();
        }
    }
}
