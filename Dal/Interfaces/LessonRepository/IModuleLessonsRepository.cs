using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;

namespace Dal.Interfaces.LessonRepository
{
    public interface IModuleLessonsRepository : IBaseRepository<CourseModule>
    {
        Task<bool> ChangeAvailableModule(CourseModule module, bool IsAvailable);
        Task<CourseModule?> GetModuleByIdWithLessons(int courseId);

        Task<Lesson?> AddLessonToModule(int moduleId, Lesson entity);
        Task<bool> DeleteLessonFromModule(int moduleId, Lesson entity);
    }
}
