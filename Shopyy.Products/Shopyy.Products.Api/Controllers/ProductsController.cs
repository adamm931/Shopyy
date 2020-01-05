using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopyy.Products.Application.Commands.Products.Create;
using Shopyy.Products.Application.Queries.Products.Details;
using Shopyy.Products.Application.Queries.Products.Filter;
using System;
using System.Threading.Tasks;

namespace Shopyy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpPut]
        public async Task<IActionResult> Filter([FromBody] FilterProducts query)
            => Ok(await _mediator.Send(query ?? new FilterProducts()));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(Guid id)
            => Ok(await _mediator.Send(new GetProductDetails(id)));
    }
}