
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;

namespace Dal.Interfaces
{
    public  interface ILanguageCourseRepository : IBaseRepository<LanguageCourse>
    {
        Task<ModuleLessons?> AddModuleToCourse(int courseId, ModuleLessons entity);
        Task<bool> DeleteModuleFromCourse(int courseId, ModuleLessons entity);

        Task<IEnumerable<LanguageCourse>> GetCourses(string? name = null, LanguageName? language = null, LanguageLevel? difficulty = null);
    }
}
