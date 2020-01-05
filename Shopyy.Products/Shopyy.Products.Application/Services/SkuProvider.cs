using Microsoft.Extensions.Options;
using Shopyy.Products.Application.Options;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Interfacaes;
using Shopyy.Products.Domain.ValueObjects;

namespace Shopyy.Products.Application.Services
{
    public class SkuProvider : ISkuProvider
    {
        private readonly IOptions<SkuOptions> _skuOptions;

        public SkuProvider(IOptions<SkuOptions> skuOptions)
        {
            _skuOptions = skuOptions;
        }

        public Sku GetSku(Product product, ProductVariant productVariant)
        {
            var schemaOptions = _skuOptions.Value;

            var schema = SkuSchema
                .Parse(schemaOptions.Schema)
                .SetBrand(productVariant.Brand)
                .SetSize(productVariant.Size)
                .SetColor(productVariant.Color)
                .SetName(product.Name
                    .Substring(0, schemaOptions.NameOffset)
                    .Trim());

            return schema.Sku;
        }
    }
}
