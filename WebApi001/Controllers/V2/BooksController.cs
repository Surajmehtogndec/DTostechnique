using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace WebApi001.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(new
            {
                Version  = "V2",
                Message = "This is the V2 of the Books API"

            });
        }
    }
}
