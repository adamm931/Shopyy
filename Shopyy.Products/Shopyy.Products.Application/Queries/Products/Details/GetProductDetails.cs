using AutoMapper;
using MediatR;
using Shopyy.Application.Mapping.Extensions;
using Shopyy.Products.Application.Common;
using Shopyy.Products.Application.Models.Response;
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
        public Guid Id { get; set; }

        public GetProductDetails(Guid id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<GetProductDetails, ProductDetailsResponse>
        {
            private readonly IProductsAppContext _context;
            private readonly IMapper _mapper;

            public Handler(IProductsAppContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDetailsResponse> Handle(GetProductDetails request, CancellationToken cancellationToken)
            {
                var spec = ProductSpecification.Create()
                    .ById(request.Id)
                    .IncludeVariants();

                var currencies = (await _context.Currencies.QueryAsync(CurrencySpecification.Create())).ToList();

                var mappingParams = new Dictionary<string, object>
                {
                    {  AutoMapperParams.Currencies, currencies }
                };

                var product = await _context.Products.SingleOrDefaultAsync(spec);

                return _mapper.Map<ProductDetailsResponse>(product, mappingParams);
            }
        }
    }
}
