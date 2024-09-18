using Domain.Entity.Content.Question;
using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces.LessonRepository
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<Lesson?> UpdateIcon(Lesson lesson, string iconPath);
        Task<Lesson?> UpdateTitle(Lesson lesson, string title);

        Task<Lesson?> ChangeAvailableLesson(Lesson lesson, bool isAvailable);

        Task<Lesson?> AddQuestionToLesson(int lessonId, BaseQuestion entity);
        Task<bool?> DeleteQuestionFromLesson(int lessonId, BaseQuestion entity);

        Task<Lesson?> AddLecture(int lesssonId, LectureBlock lecture);
        Task<bool?> DeleteLecture(int lesssonId, LectureBlock lecture);


        Task<IEnumerable<BaseQuestion?>> GetAllQuestions(int lessonId);
    }
}
