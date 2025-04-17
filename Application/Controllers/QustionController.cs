using Common.Enum;
using Common.Response.ErrorResponse;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.ILowLevelServices.LearnContentService;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("get-all{lessonId}")]
        public async Task<IActionResult> GetQuestions(int lessonId)
        {
            var response = await _questionService.GetQuestions(lessonId);

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
