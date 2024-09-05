
using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces
{
    public interface IModuleLessonsRepository : IBaseRepository<ModuleLessons>
    {
        Task<bool> ChangeAvailableModule(ModuleLessons module, bool IsAvailable);

        Task<bool> AddLessonToModule(int moduleId, Lesson entity);
        Task<bool> DeleteLessonFromModule(int moduleId, Lesson entity);
    }
}
