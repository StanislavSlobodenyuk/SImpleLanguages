
using Common.Response;
using Domain.Entity.Content.Question;

namespace Service.Interfaces
{
    public interface IQuestionService 
    {
        Task<BaseResponse<IEnumerable<BaseQuestion>>> GetQuestions(int lessonId);
    }
}
