
using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces
{
    public interface IModuleOfLessonsRepository : IBaseRepository<ModuleOfLessons>
    {
        Task<bool> ChangeAvailableModule(ModuleOfLessons module, bool IsAvailable);

        Task<bool> AddLessonToModule(int moduleId, Lesson entity);
        Task<bool> DeleteLessonFromModule(int moduleId, Lesson entity);
    }
}
