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
                var productSpec = ProductSpecification.Create();

                var products = await _context.Products
                    .FilterAsync(productSpec);

                // currencies
                var currencySpec = CurrencySpecification.Create()
                        .ForCurrencyCodeType(request.Currency)
                        .IncludeCurrencyCode();

                var currency = await _context.Currencies
                    .SingleOrDefaultAsync(currencySpec);

                return products.Select(product => new ProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    SerialNumber = product.SerialNumber,
                    ArticleNumber = product.ArticleNumber,
                    Price = new ProductPriceResponse
                    {
                        Amount = product.GetPriceForCurrency(currency),
                        Currnecy = currency.CurrencyCode.Name
                    },
                    StockCount = product.StockCount
                });
            }
        }
    }
}
