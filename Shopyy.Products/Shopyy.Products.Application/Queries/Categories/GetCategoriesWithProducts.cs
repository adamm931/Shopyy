using MediatR;
using Shopyy.Products.Application.Models.Response;

namespace Shopyy.Products.Application.Queries.Categories
{
    public class GetCategoriesWithProducts : IRequest<CategoriesWithProductsResponse>
    {
    }
}
