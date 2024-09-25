using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Dal.Interfaces.LessonRepositories
{
    public interface IQuestionRepository
    {
        Task<bool> DeleteQuestion(Lesson lesson, BaseQuestion question);
        Task<BaseQuestion?> GetQuestion(int questionId, TypeQuestion type);
    }
}
