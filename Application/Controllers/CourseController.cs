using Common.Enum;
using Domain.Entity.Content.Metadata.Course;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ILanguageCourseService _languageCourseService;

        public CourseController(ILanguageCourseService languageCourseService)
        {
            _languageCourseService = languageCourseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses([FromBody] CourseFilterDto filterDto)
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

       

    }
}
