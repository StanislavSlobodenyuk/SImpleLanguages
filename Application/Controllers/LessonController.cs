
using Common.Enum;
using Common.Response.ErrorResponse;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessoService;

        public LessonController(ILessonService lessonService)
        {
            _lessoService = lessonService;
        }

        [HttpGet("get-all{moduleId}")]
        public async Task<IActionResult> GetLesson(int moduleId)
        {
            var response = await _lessoService.GetLessons(moduleId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = response.Description });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = response.Description });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }

        [HttpPut("ChangeAvailable")]
        public async Task<IActionResult> ChangeAvailable([FromQuery] int lessonId)
        {
            var response = await _lessoService.ChangeAvailable(lessonId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = $"No lesson found with id {lessonId}." });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = "An internal server error occurred. Please try again later." });


                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }
    }
}
