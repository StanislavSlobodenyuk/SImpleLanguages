
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Dal.Interfaces
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<Lesson?> UpdateIcon(Lesson lesson, string iconPath);
        Task<Lesson?> UpdateTitle(Lesson lesson, string title);

        Task<Lesson?> GetLessonWithQuestion(int lessonId);
        Task<Lesson?> ChangeAvailableLesson(Lesson lesson, bool isAvailable);

        Task<BaseQuestion?> AddQuestionToLesson(int lessonId, BaseQuestion entity);
        Task<bool> DeleteQuestionFromLesson(int lessonId, BaseQuestion entity);

        Task<IEnumerable<BaseQuestion?>> GetAllQuestions(int lessonId);
    }
}
