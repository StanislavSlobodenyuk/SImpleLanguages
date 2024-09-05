
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;

namespace Dal.Interfaces
{
    public  interface ICourseRepository : IBaseRepository<Course>
    {
        Task<Course?> GetByLanguageCourse(string language);
        Task<Course?> GetByCodeCourse(string code);

        Task<bool> AddModuleToCourse(int courseId, ModuleOfLessons entity);
        Task<bool> DeleteModuleFromCourse(int courseId, ModuleOfLessons entity);
    }
}
