using MediatR;
using Shopyy.Application.Abstractions.Repository;
using Shopyy.Products.Application.Models.Request;
using Shopyy.Products.Application.Models.Response;
using Shopyy.Products.Domain.Entities;
using Shopyy.Products.Domain.Enumerations;
using Shopyy.Products.Domain.Interfacaes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shopyy.Products.Application.Commands.Products.Create
{
    public class CreateProductCommand : IRequest<CreatedProductResponse>
    {
        #region Command

        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<ProductVariantRequest> Variants { get; set; }

        #endregion

        #region Handler

        public class Handler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
        {
            private readonly IRepository<Category> _categories;
            private readonly ISkuProvider _skuProvider;

            public Handler(
                IRepository<Category> categories,
                ISkuProvider skuProvider)
            {
                _categories = categories;
                _skuProvider = skuProvider;
            }

            public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var category = await _categories.FindAsync(request.CategoryId);

                var product = category.AddProduct(request.Name, request.Description);

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
                            _ => throw new Exception()
                        };
                    }

                    var sku = _skuProvider.GetSku(product, variant);
                    variant.SetSku(sku);

                    product.AddVariantOrIncreaseStockCount(variant);
                }

                await _categories.UnitOfWork.SaveAsync();

                return new CreatedProductResponse
                {
                    Id = product.Id
                };
            }
        }

        #endregion
    }
}
