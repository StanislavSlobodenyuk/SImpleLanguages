
using Common.Enum;
using Common.Response.ErrorResponse;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    //public class LessonController : Controller
    //{
    //    private readonly ILessonService _lessoService;

    //    public LessonController(ILessonService lessonService)
    //    {
    //        _lessoService = lessonService;
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> GetLesson([FromQuery] int lessonId)
    //    {
    //        var response = await _lessoService.GetLesson(lessonId);

    //        switch (response.StatusCode)
    //        {
    //            case MyStatusCode.NotFound:
    //                return NotFound(new BadResponse { Message = $"No lesson found with id {lessonId}" });

    //            case MyStatusCode.InternalServerError:
    //                return StatusCode(500, new BadResponse { Message = "An internal server error occurred. Please try again later." });

    //            case MyStatusCode.OK:
    //            return Ok(response.Data);

    //        default:
    //            return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
    //        }
    //    }
    //    [HttpGet]
    //    public async Task<IActionResult> GetLessonLecture([FromQuery] int lessonId)
    //    {
    //        var response = await _lessoService.GetLessonLecture(lessonId);

    //        switch (response.StatusCode)
    //        {
    //            case MyStatusCode.NotFound:
    //                return NotFound(new BadResponse { Message = $"No lesson lecture found with id {lessonId}." });

    //            case MyStatusCode.InternalServerError:
    //                return StatusCode(500, new BadResponse { Message = "An internal server error occurred. Please try again later." });
    //            case MyStatusCode.OK:
    //                return Ok(response.Data);

    //            default:
    //                return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
    //        }
    //    }
    //    [HttpGet]
    //    public async Task<IActionResult> GetLessonPractice([FromQuery] int lessonId)
    //    {
    //        var response = await _lessoService.GetLessonPractice(lessonId);

    //        switch (response.StatusCode)
    //        {
    //            case MyStatusCode.NotFound:
    //                return NotFound(new BadResponse { Message = $"No lesson practice found with id {lessonId}." });

    //            case MyStatusCode.InternalServerError:
    //                return StatusCode(500, new BadResponse { Message = "An internal server error occurred. Please try again later." });

    //            case MyStatusCode.OK:
    //                return Ok(response.Data);

    //            default:
    //                return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
    //        }
    //    }

    //    [HttpPut]
    //    public async Task<IActionResult> ChangeAvailable([FromQuery] int lessonId)
    //    {
    //        var response = await _lessoService.ChangeAvailable(lessonId);

    //        switch (response.StatusCode)
    //        {
    //            case MyStatusCode.NotFound:
    //                return NotFound(new BadResponse { Message = $"No lesson found with id {lessonId}." });

    //            case MyStatusCode.InternalServerError:
    //                return StatusCode(500, new BadResponse { Message = "An internal server error occurred. Please try again later." });


    //            case MyStatusCode.OK:
    //                return Ok(response.Data);

    //            default:
    //                return StatusCode(500, new BadResponse { Message = "An unexpected error occurred." });
    //        }
    //    }
    //}
}
