
using Common.Enum;
using Common.Response.ErrorResponse;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.ILowLevelServices.LearnContentService;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseModuleController : Controller
    {
        private readonly ICourseModuleService _courseModuleService;

        public CourseModuleController(ICourseModuleService courseModuleService)
        {
            _courseModuleService = courseModuleService;
        }

        [HttpGet("get-all{courseId}")]
        public async Task<IActionResult> GetModules(int courseId)
        {
            var response = await _courseModuleService.GetModules(courseId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = $"Not found course module from course with id {courseId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = "Failed get modules" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new BadResponse { Message = "Parameter is not correct" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModule([FromBody] UpdateCourseModuleDto updateDto, int moduleId)
        {
            var response = await _courseModuleService.UpdateModule(updateDto, moduleId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = $"Not found course module with id {moduleId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = "Failded update module" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new BadResponse { Message = "Parameter is not correct" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }

        [HttpPut("change-access")]
        public async Task<IActionResult> ChangeAccess([FromQuery] int moduleId)
        {
            var response = await _courseModuleService.ChangeAvailableModule(moduleId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = $"Not found course module with id {moduleId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = "Failded change abailable" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }
    }
}
