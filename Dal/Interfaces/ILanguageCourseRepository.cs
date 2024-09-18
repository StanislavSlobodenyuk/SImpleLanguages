
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;

namespace Dal.Interfaces
{
    public  interface ILanguageCourseRepository : IBaseRepository<LanguageCourse>
    {
        Task<LanguageCourse?> GetCourseByLanguage(LanguageName language);
        Task<LanguageCourse?> GetCourseByIdWithModule(int courseId);

        Task<ModuleLessons?> AddModuleToCourse(int courseId, ModuleLessons entity);
        Task<bool> DeleteModuleFromCourse(int courseId, ModuleLessons entity);
    }
}
