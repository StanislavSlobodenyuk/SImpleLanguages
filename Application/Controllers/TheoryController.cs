using Common.Enum;
using Common.Response.ErrorResponse;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.ILowLevelServices.LearnContentService;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheoryController : Controller
    {
        private readonly ITheoryService _theoryService;

        public TheoryController (ITheoryService theoryService)
        {
            _theoryService = theoryService;
        }

        [HttpGet("get-all{lessonId}")]
        public async Task<IActionResult> GetTheories(int lessonId)
        {
            var response = await _theoryService.GetTheories(lessonId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = response.Description });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = response.Description });

                case MyStatusCode.BadRequest:
                    return BadRequest(new BadResponse { Message = response.Description });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }
    }
}
