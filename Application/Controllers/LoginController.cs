using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] object data)
        {
            var a = data;
            return Ok("Все ок");
        }
    }
}
