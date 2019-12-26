using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopyy.Products.Application.Queries.GetProducts;
using System.Threading.Tasks;

namespace Shopyy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Filter()
        {
            return Ok(await _mediator.Send(new GetProductsQuery()));
        }
    }
}