
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;

namespace Dal.Interfaces
{
    public  interface ILanguageCourseRepository : IBaseRepository<LanguageCourse>
    {
        Task<LanguageCourse?> GetCourseByLanguage(string language);
        Task<LanguageCourse?> GetCourseByCode(string code);

        Task<bool> AddModuleToCourse(int courseId, ModuleLessons entity);
        Task<bool> DeleteModuleFromCourse(int courseId, ModuleLessons entity);
    }
}
