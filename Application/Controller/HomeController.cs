using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult CheckApi()
        {
            var response = new { Message = "Server work" };
            return Ok(response);
        }
    }
}
