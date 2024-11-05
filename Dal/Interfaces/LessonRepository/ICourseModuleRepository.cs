using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces.LessonRepositories
{
    public interface ICourseModuleRepository : IBaseRepository<CourseModule>
    {
        Task<bool> ChangeAvailableModule(CourseModule module);

        Task<Lesson?> AddLessonToModule(Lesson lesson, int moduleId);
        Task<bool> DeleteLessonFromModule(CourseModule module, Lesson lesson);
    }
}
