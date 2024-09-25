
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Dal.Interfaces.QuestionRepository
{
    public interface IBaseQuestionRepository
    {
        Task<bool> DeleteQuestion(int questionId, TypeQuestion type);
        Task<BaseQuestion?> GetQuestion(int questionId, TypeQuestion type);
    }
}
