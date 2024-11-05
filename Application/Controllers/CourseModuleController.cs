
using Common.Enum;
using Common.Response.ErrorResponse;
using Domain.Entity.Content.Lessons;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class CourseModuleController : Controller
    //{
    //    private readonly ICourseModuleService _courseModuleService;

    //    public CourseModuleController(ICourseModuleService courseModuleService)
    //    {
    //        _courseModuleService = courseModuleService;
    //    }

    //    public async Task<IActionResult> GetModule([FromQuery] int moduleId)
    //    {
    //        var response = await _courseModuleService.GetModule(moduleId);

    //        switch (response.StatusCode)
    //        {
    //            case MyStatusCode.NotFound:
    //                return NotFound(new BadResponse { Message = $"Not found course module with id {moduleId}" });

    //            case MyStatusCode.InternalServerError:
    //                return StatusCode(500, new BadResponse { Message = "Failded get module" });

    //            case MyStatusCode.BadRequest:
    //                return BadRequest(new BadResponse { Message = "Parameter is not correct" });

    //            case MyStatusCode.OK:
    //                return Ok(true);

    //            default:
    //                return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
    //        }
    //    }
    //    public async Task<IActionResult> UpdateModule([FromBody] UpdateCourseModuleDto updateDto, int moduleId)
    //    {
    //        var response = await _courseModuleService.UpdateModule(updateDto, moduleId);

    //        switch (response.StatusCode)
    //        {
    //            case MyStatusCode.NotFound:
    //                return NotFound(new BadResponse { Message = $"Not found course module with id {moduleId}" });

    //            case MyStatusCode.InternalServerError:
    //                return StatusCode(500, new BadResponse { Message = "Failded update module" });

    //            case MyStatusCode.BadRequest:
    //                return BadRequest(new BadResponse { Message = "Parameter is not correct" });

    //            case MyStatusCode.OK:
    //                return Ok(response.Data);

    //            default:
    //                return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
    //        }
    //    }
    //    public async Task<IActionResult> ChangeAccess([FromQuery] int moduleId)
    //    {
    //        var response = await _courseModuleService.ChangeAvailableModule(moduleId);

    //        switch (response.StatusCode)
    //        {
    //            case MyStatusCode.NotFound:
    //                return NotFound(new BadResponse { Message = $"Not found course module with id {moduleId}" });

    //            case MyStatusCode.InternalServerError:
    //                return StatusCode(500, new BadResponse { Message = "Failded change abailable" });

    //            case MyStatusCode.OK:
    //                return Ok(response.Data);

    //            default:
    //                return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
    //        }
    //    }

    //    public async Task<IActionResult> AddLesson([FromBody] Lesson lesson, int moduleId)
    //    {
    //        var response = await _courseModuleService.AddLesson(lesson, moduleId);

    //        switch (response.StatusCode)
    //        {
    //            case MyStatusCode.NotFound:
    //                return NotFound(new BadResponse { Message = $"Not found module with id {moduleId}" });

    //            case MyStatusCode.BadRequest:
    //                return BadRequest(new BadResponse { Message = "Parameter is not correct" });

    //            case MyStatusCode.InternalServerError:
    //                return StatusCode(500, new BadResponse { Message = "Failed create new lesson and add its to module" });

    //            case MyStatusCode.OK:
    //                return Ok(response.Data);

    //            default:
    //                return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
    //        }
    //    }
        //public async Task<IActionResult> DeleteLesson([FromQuery] int moduleId, int lessonId)
        //{
        //    var response = await _courseModuleService.DeleteLesson(moduleId, lessonId);

        //    switch (response.StatusCode)
        //    {
        //        case MyStatusCode.NotFound:
        //            return NotFound(new BadResponse { Message = $"Not found module with id {moduleId}" });

        //        case MyStatusCode.InternalServerError:
        //            return StatusCode(500, new BadResponse { Message = "Failed delete lesson from module" });

        //        case MyStatusCode.OK:
        //            return Ok(response.Data);

        //        default:
        //            return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
        //    }
        //}
    //}
}
