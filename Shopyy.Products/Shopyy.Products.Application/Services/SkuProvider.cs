using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Interfacaes;
using Shopyy.Products.Domain.Specifications;
using Shopyy.Products.Domain.ValueObjects;
using System.Linq;
using System.Threading.Tasks;

namespace Shopyy.Products.Application.Services
{
    public class SkuProvider : ISkuProvider
    {
        private const int NameOffset = 3;

        private readonly IProductsAppContext _context;

        public SkuProvider(IProductsAppContext context)
        {
            _context = context;
        }

        public async Task<Sku> GenerateSku(Product product, ProductVariant productVariant)
        {
            Sku sku = product.Name.Substring(0, NameOffset);

            var generatedSku = productVariant.Attributes
                .Aggregate(sku, (current, attribute) => current.AppendSegment(attribute.ShortName));

            var count = await CountAsync(generatedSku);

            return count == 0 ? generatedSku : generatedSku.AppendSegment(count.ToString());
        }

        private async Task<long> CountAsync(Sku sku)
        {
            var skuSpec = ProductSpecification.Create()
                .ForSku(sku)
                .IncludeVariations();

            return await _context.Products.CountAsync(skuSpec);
        }
    }
}
