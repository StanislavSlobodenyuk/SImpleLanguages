
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Dal.Interfaces
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<IEnumerable<Lesson>> GetLessonByDifficult(LanguageLevel level);

        Task<bool> AddQuestionToLesson(int lessonId, BaseQuestion entity);
        Task<bool> DeleteQuestionFromLesson(int lessonId, BaseQuestion entity);

        Task<IEnumerable<BaseQuestion?>> GetAllQuestions(int lessonId);
    }
}
