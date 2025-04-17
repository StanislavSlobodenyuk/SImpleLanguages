using Common.Enum;
using Common.Response.ErrorResponse;
using Domain.Entity.Content.CourseContent;
using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.ILowLevelServices.LearnContentService;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,User")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetCourses([FromQuery] string? searchTitle, [FromQuery] string? language, [FromQuery] string? level,
            [FromQuery] string? lessonCount, [FromQuery] string? cost, [FromQuery] bool inDevelopment)
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

            var response = await _courseService.GetFillterCourses(filterDto);

            
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

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourse(int courseId) 
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = authHeader.StartsWith("Bearer ") ? authHeader.Substring(7) : null;

            // Логируем токен (не рекомендуется делать это в продакшн-режиме!)
            if (!string.IsNullOrEmpty(token))
            {
                Console.WriteLine($"Received Token: {token}");
            }

            var response = await _courseService.GetCourse(courseId);

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

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course languageCourse)
        {
            var response = await _courseService.CreateCourse(languageCourse);

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
        [Authorize]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var response = await _courseService.DeleteCourse(courseId);

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
            var response = await _courseService.UpdateCourse(updateData, courseId);

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
