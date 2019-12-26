using Microsoft.AspNetCore.Mvc;

namespace Shopyy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        public ProductsApiController()
        {

        }

        [HttpPut]
        public IActionResult Filter()
        {
            return Ok(new[] { "123", "123" });
        }
    }
}