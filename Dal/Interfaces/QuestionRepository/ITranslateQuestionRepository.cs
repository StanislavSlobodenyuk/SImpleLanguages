
using Domain.Entity.Content.Question;

namespace Dal.Interfaces.QuestionRepository
{
    public interface ITranslateQuestionRepository : IBaseRepository<TranslateQuestion>
    {
        Task<TranslateQuestion> CreateTranslateQuestion(TranslateQuestion translationQuestion);
    }
}
