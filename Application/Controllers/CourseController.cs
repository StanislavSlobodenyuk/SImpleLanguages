using Common.Enum;
using Common.Response.ErrorResponse;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.CourseContent;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Domain.Enum;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _languageCourseService;

        public CourseController(ICourseService languageCourseService)
        {
            _languageCourseService = languageCourseService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetCourses(
            [FromQuery] string? searchTitle,
            [FromQuery] string? language,
            [FromQuery] string? level,
            [FromQuery] string? lessonCount,
            [FromQuery] string? cost,
            [FromQuery] bool inDevelopment)
        {
            CourseFilterDto filterDto = new CourseFilterDto
            {
                SearchTitle = searchTitle ?? "",
                Language = language,
                Level = level,
                LessonCount = lessonCount,
                Cost = cost,
                InDevelopment = inDevelopment
            };

            var response = await _languageCourseService.GetFillterCourses(filterDto);

            
            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = "No courses found by filter." });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = "An internal server error occurred. Please try again later." });

                case MyStatusCode.BadRequest:
                    return BadRequest(new BadResponse { Message = "Parameter is not correct" });

                case MyStatusCode.OK:
                    return Ok(response.Data); 

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourse(int courseId) 
        {
            var response = await _languageCourseService.GetCourseById(courseId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = $"Not found course with id {courseId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = "An internal server error occurred. Please try again later." });

                case MyStatusCode.BadRequest:
                    return BadRequest(new BadResponse { Message = "Parameter is not correct" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course languageCourse)
        {
            var response = await _languageCourseService.CreateCourse(languageCourse);

            switch (response.StatusCode)
            {
                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = "Failed to create course" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new BadResponse { Message = "Parameter is not correct"});

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }
       
        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var response = await _languageCourseService.DeleteCourse(courseId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = $"Not found course with id {courseId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = "Failded to deleted course" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new BadResponse { Message = "Parameter is not correct" });

                case MyStatusCode.OK:
                    return Ok(response.Data);

                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }
       
        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseDto updateData, int courseId)
        {
            var response = await _languageCourseService.UpdateCourse(updateData, courseId);

            switch (response.StatusCode)
            {
                case MyStatusCode.NotFound:
                    return NotFound(new BadResponse { Message = $"Not found course with id {courseId}" });

                case MyStatusCode.InternalServerError:
                    return StatusCode(500, new BadResponse { Message = "Parameter is bad" });

                case MyStatusCode.BadRequest:
                    return BadRequest(new BadResponse { Message = "Parameter is not correct" });

                case MyStatusCode.OK:
                    return Ok(response.Data);
                default:
                    return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
            }
        }
        
    }
}
