using MediatR;
using Shopyy.Products.Application.Models.Request;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Interfacaes;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopyy.Products.Application.Commands.Products.Create
{
    public class CreateProductCommand : IRequest<CreatedProductResponse>
    {
        #region Command

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<ProductVariantRequest> Variants { get; set; }

        #endregion

        #region Handler

        public class Handler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
        {
            private readonly IProductsAppContext _context;
            private readonly ISkuProvider _skuProvider;

            public Handler(IProductsAppContext context, ISkuProvider skuProvider)
            {
                _context = context;
                _skuProvider = skuProvider;
            }

            public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product(request.Name, request.Description);

                foreach (var variantRequest in request.Variants)
                {
                    var variant = new ProductVariant(variantRequest.Price, variantRequest.StockCount);

                    foreach (var attributeRequest in variantRequest.Attributes)
                    {
                        // TODO: move this to factory
                        variant = attributeRequest.Type switch
                        {
                            ProductAttributeTypeId.Brand => variant.AddBrand(attributeRequest.Brand.Value),
                            ProductAttributeTypeId.Color => variant.AddColor(attributeRequest.Color.Value),
                            ProductAttributeTypeId.Size => variant.AddSize(attributeRequest.Size.Value),
                            _ => throw new System.Exception()
                        };
                    }

                    var sku = _skuProvider.GetSku(product, variant);
                    variant.SetSku(sku);

                    product.AddVariantOrIncreaseStockCount(variant);
                }

                _context.Products.Add(product);

                await _context.Products.UnitOfWork.SaveAsync();

                return new CreatedProductResponse
                {
                    Id = product.Id
                };
            }
        }

        #endregion
    }
}
