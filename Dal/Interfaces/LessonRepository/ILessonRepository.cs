using Domain.Entity.Content.Question;
using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces.LessonRepositories
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<Lesson?> GetLecture(int lessonId);
        Task<Lesson?> GetPractice(int lessonId);

        Task<Lesson?> ChangeAvailableLesson(Lesson lesson);
    }
}
