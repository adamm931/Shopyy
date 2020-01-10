using AutoMapper;
using MediatR;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Common;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopyy.Products.Application.Queries.Products.Details
{
    public class GetProductDetails : IRequest<ProductDetailsResponse>
    {
        #region Request
        public Guid CategoryId { get; set; }

        public Guid ProductId { get; set; }

        public GetProductDetails(Guid categoryId, Guid productId)
        {
            CategoryId = categoryId;
            ProductId = productId;
        }

        #endregion

        #region Handler

        public class Handler : IRequestHandler<GetProductDetails, ProductDetailsResponse>
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

            public async Task<ProductDetailsResponse> Handle(GetProductDetails request, CancellationToken cancellationToken)
            {
                var spec = CategorySpecification.Create()
                    .ById(request.CategoryId)
                    .IncludeProducts();

                var currencies = (await _currencies.QueryAsync(CurrencySpecification.Create())).ToList();

                var mappingParams = new Dictionary<string, object>
                {
                    {  AutoMapperParams.Currencies, currencies }
                };

                var product = (await _categories.SingleOrDefaultAsync(spec))
                    .GetProduct(request.ProductId);

                return _mapper.Map<ProductDetailsResponse>(product, mappingParams);
            }
        }

        #endregion
    }
}
