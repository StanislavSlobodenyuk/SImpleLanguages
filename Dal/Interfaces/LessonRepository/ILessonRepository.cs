using Domain.Entity.Content.Question;
using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces.LessonRepositories
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<Lesson?> ChangeAvailableLesson(Lesson lesson);
    }
}
