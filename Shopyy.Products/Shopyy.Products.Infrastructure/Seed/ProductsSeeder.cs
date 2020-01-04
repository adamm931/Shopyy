using Microsoft.Extensions.Options;
using Shopyy.Infrastructure.Interfaces;
using Shopyy.Infrastructure.Options;
using Shopyy.Products.Application;
using Shopyy.Products.Domain.Interfacaes;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Seed
{
    public class ProductsSeeder : ISeeder
    {
        private readonly IProductsAppContext _productsContext;
        private readonly IDatabaseCreator _databaseCreator;
        private readonly IEnumerationsSeeder _enumerationsSeeder;
        private readonly IOptions<SeedOptions> _seedOptions;
        private readonly ISkuProvider _skuProvider;

        public ProductsSeeder(
            IProductsAppContext productsContext,
            IDatabaseCreator databaseInitializer,
            IEnumerationsSeeder enumerationsSeeder,
            IOptions<SeedOptions> seedOptions,
            ISkuProvider skuProvider
            )
        {
            _productsContext = productsContext;
            _databaseCreator = databaseInitializer;
            _enumerationsSeeder = enumerationsSeeder;
            _seedOptions = seedOptions;
            _skuProvider = skuProvider;
        }

        public async Task SeedAsync()
        {
            var recreate = _seedOptions.Value.Recreate;
            var isCreated = await _databaseCreator.CreateAsync(recreate);

            if (!isCreated)
            {
                return;
            }

            _productsContext.Products.AddRange(SeederData.GetProducts(_skuProvider));
            _productsContext.Currencies.AddRange(SeederData.GetCurrencies());

            _enumerationsSeeder.SeedEnumerations();

            await _productsContext.Products.UnitOfWork.SaveAsync();
        }
    }
}
