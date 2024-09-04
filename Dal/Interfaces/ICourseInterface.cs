
using Domain.Entity.Content.Metadata.Course;

namespace Dal.Interfaces
{
    public  interface ICourseInterface : IBaseRepository<Course>
    {
        Task<Course?> GetByLanguageCourse(string language);
        Task<Course?> GetByCodeCourse(string code);
    }
}
