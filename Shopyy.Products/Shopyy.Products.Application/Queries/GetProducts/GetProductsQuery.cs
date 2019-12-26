using MediatR;
using Shopyy.Products.Application.Models;
using Shopyy.Products.Domain.Enumerations;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopyy.Products.Application.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductVm>>
    {
        public class Handler : IRequestHandler<GetProductsQuery, IEnumerable<ProductVm>>
        {
            private readonly IProductsAppContext _context;

            public Handler(IProductsAppContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ProductVm>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ListAsync();
                var currencies = await _context.Currencies.ListAsync();

                var rsd = currencies.Single(curr => curr.CurrnecyCodeTypeId == CurrnecyCodeTypeId.RSD);

                return products.Select(product => new ProductVm
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    SerialNumber = product.SerialNumber,
                    ArticleNumber = product.ArticleNumber,
                    Price = new ProductPriceVm
                    {
                        Amount = product.GetPriceForCurrency(rsd),
                        Currnecy = rsd.CurrencyCode.Name
                    },
                    StockCount = product.StockCount
                });
            }
        }
    }
}
