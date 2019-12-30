using MediatR;
using Shopyy.Products.Application.Models.Request;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Factories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopyy.Products.Application.Commands.Products.Create
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<ProductVariantRequest> Variants { get; set; }

        public class Handler : IRequestHandler<CreateProductCommand, Guid>
        {
            private readonly IProductsAppContext _context;

            public Handler(IProductsAppContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product(request.Name, request.Description);

                var variants = request.Variants
                    .Select(varaint => new ProductVariant(varaint.Price, varaint.StockCount)
                        .AddAttributes(varaint.Attributes
                            .Select(attr => ProductAttributeFactory.ByType(attr.Type, attr.Value))));

                product.AddVariants(variants);

                _context.Products.Add(product);
                await _context.Products.UnitOfWork.SaveAsync();

                return product.Id;
            }
        }
    }
}
