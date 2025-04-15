using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProfileController : Controller
    {
        //[HttpGet("get-profile")]
        //public IActionResult GetProfile()
        //{

        //}

        //[HttpGet("get-statistic")]
        //public IActionResult GetStatistic()
        //{

        //}

        //[HttpPost("share-statistic")]
        //public IActionResult ShareStatistic()
        //{

        //}

        //[HttpGet("get-awards")]
        //public IActionResult GetAwards()
        //{

        //}

        //[HttpPut("update-user-data")]
        //public IActionResult UpdateUserData()
        //{

        //}

        //[HttpPost("add-sociable")]
        //public IActionResult AddSociable()
        //{

        //}
    }
}
