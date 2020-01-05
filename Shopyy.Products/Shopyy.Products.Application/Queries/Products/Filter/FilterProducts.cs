using AutoMapper;
using MediatR;
using Shopyy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Common;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopyy.Products.Application.Queries.Products.Filter
{
    public class FilterProducts : IRequest<IEnumerable<ProductResponse>>
    {
        public CurrnecyCodeTypeId Currency { get; set; } = CurrnecyCodeTypeId.EUR;

        public class Handler : IRequestHandler<FilterProducts, IEnumerable<ProductResponse>>
        {
            private readonly IProductsAppContext _context;
            private readonly IMapper _mapper;

            public Handler(
                IProductsAppContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ProductResponse>> Handle(FilterProducts request, CancellationToken cancellationToken)
            {
                // products
                var productSpec = ProductSpecification.Create()
                    .IncludeVariants();

                var products = await _context.Products
                    .QueryAsync(productSpec);

                // currencies
                var currencySpec = CurrencySpecification.Create()
                    .ForCurrencyCodeType(request.Currency)
                    .IncludeCurrencyCode();

                var currency = await _context.Currencies
                    .SingleOrDefaultAsync(currencySpec);

                var mappingParams = new Dictionary<string, object>
                {
                    { AutoMapperParams.Currency, currency }
                };

                return _mapper.Map<IEnumerable<ProductResponse>>(products, mappingParams);
            }
        }
    }
}
