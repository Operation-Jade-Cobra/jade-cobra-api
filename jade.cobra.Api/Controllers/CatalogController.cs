using Microsoft.AspNetCore.Mvc;
using jade.cobra.Domain.Catalog;

namespace jade.cobra.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase{
        [HttpGet]
        public IActionResult GetItems(){
            return Ok("Hello World!");
        }
    }
}