
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;

namespace Dal.Interfaces
{
    public  interface ILanguageCourseRepository : IBaseRepository<LanguageCourse>
    {
        Task<CourseModule?> AddModuleToCourse(int courseId, CourseModule entity);
        Task<bool> DeleteModuleFromCourse(LanguageCourse course, CourseModule module);

        Task<IEnumerable<LanguageCourse>> GetCourses(string? name = null, LanguageName? language = null, LanguageLevel? difficulty = null);
    }
}
