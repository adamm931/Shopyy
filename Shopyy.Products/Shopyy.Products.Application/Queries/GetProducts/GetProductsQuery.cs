using MediatR;
using Shopyy.Products.Application.Models;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopyy.Products.Application.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductResponse>>
    {
        public CurrnecyCodeTypeId Currency { get; set; }

        public class Handler : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>
        {
            private readonly IProductsAppContext _context;

            public Handler(IProductsAppContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                // products
                var productSpec = ProductSpecification.Create()
                    .IncludeVariations();

                var products = await _context.Products
                    .FilterAsync(productSpec);

                // currencies
                var currencySpec = CurrencySpecification.Create()
                    .ForCurrencyCodeType(request.Currency)
                    .IncludeCurrencyCode();

                var currency = await _context.Currencies
                    .SingleOrDefaultAsync(currencySpec);

                // replace this with Auto Mapper
                return products
                    .SelectMany(product => product.Variants)
                    .Select(variant =>
                    new ProductResponse
                    {
                        Id = variant.ProductId,
                        Name = variant.Product.Name,
                        Description = variant.Product.Description,
                        SerialNumber = variant.Product.SerialNumber,
                        Price = new ProductPriceResponse
                        {
                            Amount = variant.GetPriceForCurrency(currency),
                            Currnecy = currency.CurrencyCode.Name
                        },
                        StockCount = variant.StockCount,
                        Attributes = variant.Attributes.Select(attribute =>
                        new ProductAttributeResponse
                        {
                            Name = attribute.AttributeTypeId.ToString(),
                            Value = attribute.Value
                        }).ToList()
                    });
            }
        }
    }
}
