
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Dal.Interfaces.QuestionRepository
{
    public interface IBaseQuestionRepository
    {
        Task<bool> DeleteQuestion(int questionId, QuestionType type);
        Task<BaseQuestion?> GetQuestion(int questionId, QuestionType type);
        Task<string?> GetRigthAnswer( int questionId, QuestionType type);
    }
}
