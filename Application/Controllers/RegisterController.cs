using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] object data)
        {
            var a = data;
            return Ok("Все ок");
        }
    }
}
