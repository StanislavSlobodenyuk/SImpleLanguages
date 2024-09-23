using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;

namespace Dal.Interfaces.LessonRepository
{
    public interface ICourseModuleRepository : IBaseRepository<CourseModule>
    {
        Task<bool> ChangeAvailableModule(CourseModule module);

        Task<Lesson?> AddLessonToModule(Lesson lesson, int moduleId);
        Task<bool> DeleteLessonFromModule(CourseModule module, Lesson lesson);
    }
}
