using Microsoft.Extensions.Options;
using Shopyy.Infrastructure.Interfaces;
using Shopyy.Infrastructure.Options;
using Shopyy.Products.Application;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Seed
{
    public class ProductsSeeder : ISeeder
    {
        private readonly IProductsAppContext _productsContext;
        private readonly IDatabaseCreator _databaseCreator;
        private readonly IOptions<SeedOptions> _seedOptions;

        public ProductsSeeder(
            IProductsAppContext productsContext,
            IDatabaseCreator databaseInitializer,
            IOptions<SeedOptions> seedOptions)
        {
            _productsContext = productsContext;
            _databaseCreator = databaseInitializer;
            _seedOptions = seedOptions;
        }

        public async Task SeedAsync()
        {
            var recreate = _seedOptions.Value.Recreate;
            var isCreated = await _databaseCreator.CreateAsync(recreate);

            if (!isCreated)
            {
                return;
            }

            _productsContext.Products.AddRange(SeederData.GetProducts());
            _productsContext.Currencies.AddRange(SeederData.GetCurrencies());
            _productsContext.CurrencyCodes.AddRange(SeederData.GetCurrencyCodes());
            _productsContext.ProductAttributeTypes.AddRange(SeederData.GetProductAttributeTypes());

            await _productsContext.Products.UnitOfWork.SaveAsync();
        }
    }
}
