using Domain.Entity.Content.CourseContent;
using Domain.Enum;

namespace Dal.Interfaces.LearnContent
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<IEnumerable<Course>> GetFillterCourses(
            string? title,
            LanguageName language,
            LanguageLevel level,
            int[] lessonCount,
            string? cost,
            bool inDevelopment
        );
    }
}
