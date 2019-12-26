using Shopyy.Infrastructure.Interfaces;
using Shopyy.Products.Application;
using System.Threading.Tasks;

namespace Shopyy.Infrastructure.Seed
{
    public class ProductsSeeder : ISeeder
    {
        private readonly IProductsAppContext _productsContext;
        private readonly IDatabaseCreator _databaseCreator;

        public ProductsSeeder(
            IProductsAppContext productsContext,
            IDatabaseCreator databaseInitializer)
        {
            _productsContext = productsContext;
            _databaseCreator = databaseInitializer;
        }

        public async Task SeedAsync()
        {
            var isCreated = await _databaseCreator.CreateAsync();

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
