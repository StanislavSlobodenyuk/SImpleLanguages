using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;

namespace Dal.Interfaces.LessonRepository
{
    public interface IModuleLessonsRepository : IBaseRepository<ModuleLessons>
    {
        Task<bool> ChangeAvailableModule(ModuleLessons module, bool IsAvailable);
        Task<ModuleLessons?> GetModuleByIdWithLessons(int courseId);

        Task<Lesson?> AddLessonToModule(int moduleId, Lesson entity);
        Task<bool> DeleteLessonFromModule(int moduleId, Lesson entity);
    }
}
