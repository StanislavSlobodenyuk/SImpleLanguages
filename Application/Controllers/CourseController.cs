using Common.Enum;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ILanguageCourseService _languageCourseService;

        public CourseController(ILanguageCourseService languageCourseService)
        {
            _languageCourseService = languageCourseService;
        }

        [HttpGet("ViewCourses")]
        public async Task<IActionResult> ViewCourses([FromQuery] CourseFilterDto filterDto)
        {
            var response = await _languageCourseService.GetFillterCourses(filterDto);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = "No courses found matching the criteria." });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "An internal server error occurred. Please try again later." });

                case MyStatusCode.BadRequest:
                    return BadRequest(new { message = "The request was invalid or cannot be processed." });

                case MyStatusCode.OK:
                    return Ok(response.Data); 

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpGet] 
        public async Task<IActionResult> ViewCourse([FromQuery] int courseId) 
        {
            var response = await _languageCourseService.GetCourseById(courseId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = "No courses found matching the criteria." });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "An internal server error occurred. Please try again later." });

                case MyStatusCode.BadRequest:
                    return BadRequest(new { message = "The request was invalid or cannot be processed." });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddModuleToCourse([FromBody] CourseModule courseModule, int courseId) 
        {
            var response = await _languageCourseService.AddModule(courseModule, courseId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = $"Not found course with id {courseId}" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new { message = "Parameter is bad" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "Failed create new module and add its to course" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteModuleFromCourse(int courseId, int moduleId)
        {
            var response = await _languageCourseService.DeleteModule(courseId, moduleId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = $"Not found course with id {courseId}" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new { message = "Parameter is bad" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = $"Failed delete module {moduleId} from course {courseId}" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] LanguageCourse languageCourse) 
        {
            var response = await _languageCourseService.CreateCourse(languageCourse);

            switch (response.StatusCode)
            {
                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "Failed to create course" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new { message = "Parameters are not correct" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
        
        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var response = await _languageCourseService.DeleteCourse(courseId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = "Not found course" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new { message = "Failded to deleted course" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new { message = "Parameter is not correct" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }

        }
        
        [HttpPut("{courseId}")] 
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseDto updateData, int courseId)
        {
            var response = await _languageCourseService.UpdateCourse(updateData, courseId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new { message = $"Not found course with id {courseId}" });
                case MyStatusCode.BadRequest:
                    return NotFound(new { message = "Parameter is bad" });
                case MyStatusCode.InternalServerError:
                    return NotFound(new { message = $"Failed update course" });
                case MyStatusCode.OK:
                    return Ok(response.Data);
                default:
                    return StatusCode(500, new { message = "An unexpected error occurred." });
            }

        }
    }
}
