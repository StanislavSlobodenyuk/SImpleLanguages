using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DairyTaskController : Controller
    {

        //[HttpGet("get-task-dairy")]
        //public IActionResult GetTaskDairy()
        //{

        //}

        //[HttpPost("create-record")]
        //public IActionResult CreateRecord()
        //{

        //}

        //[HttpPut("update-record")]
        //public IActionResult UpdateRecord()
        //{

        //}

        //[HttpDelete("delete-record")]
        //public IActionResult DeleteRecord()
        //{

        //}

        //[HttpPost("dairy-task-complete")]
        //public IActionResult DairyTaskComplete()
        //{

        //}
    }
}
