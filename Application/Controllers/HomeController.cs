
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult CheckApi()
        {
            var response = new { message = "Server work" };
            return Ok(response);
        }
    }
}
