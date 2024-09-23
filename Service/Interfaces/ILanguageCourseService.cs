
using Common.Response;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Dto;

namespace Service.Interfaces
{
    public interface ILanguageCourseService
    {
        Task<BaseResponse<LanguageCourse>> CreateCourse(LanguageCourse course);
        Task<BaseResponse<bool>> DeleteCourse(int courseID);
        Task<BaseResponse<LanguageCourse>> UpdateCourse(UpdateCourseDto course, int courseId);

        Task<BaseResponse<LanguageCourse>> GetCourseById(int id);

        Task<BaseResponse<LanguageCourse>> AddModule(CourseModule moduleOfLessons, int courseId);
        Task<BaseResponse<bool>> DeleteModule(int courseId, int moduleId);
        Task<BaseResponse<IEnumerable<LanguageCourse>>> GetFillterCourses(CourseFilterDto courseFilter);

    }
}
