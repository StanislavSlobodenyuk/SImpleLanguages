
using Common.Enum;
using Domain.Entity.Content.Lessons;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleLessonController : Controller
    {
        private readonly ICourseModuleService _courseModuleService;

        public ModuleLessonController(ICourseModuleService courseModuleService)
        {
            _courseModuleService = courseModuleService;
        }

        public async Task<ActionResult> GetModule([FromQuery] int moduleId ) 
        {
            var response = await _courseModuleService.GetModule(moduleId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = $"Not found course module with id {moduleId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "Failded get module"});

                case MyStatusCode.BadRequest:
                    return BadRequest(new { message = "Parameter is not correct" });

                case MyStatusCode.OK:
                    return Ok(true);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
        public async Task<ActionResult> UpdateModule([FromBody] CourseModuleUpdateDto updateDto, int moduleId)
        {
            var response = await _courseModuleService.UpdateModule(updateDto, moduleId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = $"Not found course module with id {moduleId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "Failded update module" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new { message = "Parameter is not correct" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
        public async Task<ActionResult> ChangeAccess([FromQuery] int moduleId)
        {
            var response = await _courseModuleService.ChangeAvailableModule(moduleId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = $"Not found course module with id {moduleId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "Failded change abailable" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        public async Task<ActionResult> CreateAndAddLesson([FromBody] Lesson lesson, int moduleId)
        {
            var response = await _courseModuleService.AddLesson(lesson, moduleId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = $"Not found module with id {moduleId}" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new { message = "Parameter is bad" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "Failed create new lesson and add its to module" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
        public async Task<ActionResult> DeleteLessonFromModule([FromQuery] int moduleId, int lessonId)
        {
            var response = await _courseModuleService.DeleteLesson(moduleId, lessonId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = $"Not found module with id {moduleId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "Failed delete lesson from module" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
    }
}
