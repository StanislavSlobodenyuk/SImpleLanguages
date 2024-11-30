
using Common.Response;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.CourseContent;
using Dto;

namespace Service.Interfaces
{
    public interface ICourseService
    {
        Task<BaseResponse<IEnumerable<Course>>> GetFillterCourses(CourseFilterDto courseFilter);
        Task<BaseResponse<Course>> GetCourse(int id);
        Task<BaseResponse<Course>> CreateCourse(Course course);
        Task<BaseResponse<bool>> DeleteCourse(int courseID);
        Task<BaseResponse<Course>> UpdateCourse(UpdateCourseDto course, int courseId);
    }
}
