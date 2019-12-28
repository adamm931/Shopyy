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
            var recreate = _seedOptions.Value.Force;
            var isCreated = await _databaseCreator.CreateAsync(recreate);

            if (!isCreated)
            {
                return;
            }

            var products = SeederData.GetProducts();
            var currencies = SeederData.GetCurrencies();
            var currencyCodes = SeederData.GetCurrencyCodes();

            _productsContext.Products.AddRange(products);
            _productsContext.Currencies.AddRange(currencies);
            _productsContext.CurrencyCodes.AddRange(currencyCodes);

            await _productsContext.Products.UnitOfWork.SaveAsync();
        }
    }
}
