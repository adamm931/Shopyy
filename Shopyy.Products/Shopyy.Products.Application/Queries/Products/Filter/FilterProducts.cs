using AutoMapper;
using MediatR;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Common;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopyy.Products.Application.Queries.Products.Filter
{
    public class FilterProducts : IRequest<IEnumerable<ProductResponse>>
    {
        #region Request

        public Guid CategoryId { get; set; }

        public CurrnecyCodeTypeId Currency { get; set; } = CurrnecyCodeTypeId.EUR;

        #endregion

        #region Handler

        public class Handler : IRequestHandler<FilterProducts, IEnumerable<ProductResponse>>
        {
            private readonly IRepository<Category> _categories;
            private readonly IRepository<Currency> _currencies;

            private readonly IMapper _mapper;

            public Handler(
                IRepository<Category> categories,
                IRepository<Currency> currencies,
                IMapper mapper)
            {
                _categories = categories;
                _currencies = currencies;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ProductResponse>> Handle(FilterProducts request, CancellationToken cancellationToken)
            {
                // products
                var categorySpec = CategorySpecification.Create()
                    .IncludeProducts();

                var products = (await _categories
                    .QueryAsync(categorySpec))
                    .SelectMany(category => category.Products);

                // currencies
                var currencySpec = CurrencySpecification.Create()
                    .ForCurrencyCodeType(request.Currency)
                    .IncludeCurrencyCode();

                var currency = await _currencies
                    .SingleOrDefaultAsync(currencySpec);

                var mappingParams = new Dictionary<string, object>
                {
                    { AutoMapperParams.Currency, currency }
                };

                return _mapper.Map<IEnumerable<ProductResponse>>(products, mappingParams);
            }
        }

        #endregion
    }
}
