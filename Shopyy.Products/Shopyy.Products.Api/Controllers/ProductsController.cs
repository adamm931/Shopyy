using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopyy.Products.Application.Queries.GetProducts;
using System.Threading.Tasks;

namespace Shopyy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Filter([FromBody] GetProductsQuery query)
        {
            return Ok(await _mediator.Send(query ?? new GetProductsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GetProductsQuery command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}