
using Common.Response;
using Domain.Entity.Content.Question;
using Dto;

namespace Service.Interfaces.ILowLevelServices.LearnContentService
{
    public interface IQuestionService
    {
        Task<BaseResponse<List<QuestionDto>>> GetQuestions(int lessonId);
    }
}
