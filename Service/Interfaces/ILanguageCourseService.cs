
using Common.Response;
using Common.Response.UpdateResponse;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;

namespace Service.Interfaces
{
    public interface ILanguageCourseService
    {
        Task<BaseResponse<LanguageCourse>> CreateCourse(string languageName, string code, string IconPath);
        Task<BaseResponse<bool>> DeleteCourse(int courseID);
        Task<BaseResponse<LanguageCourse>> Change(int courseId, UpdateCourseRequest updateCourseRequest);

        Task<BaseResponse<LanguageCourse>> GetCourseByName(string languageName);
        Task<BaseResponse<LanguageCourse>> GetCourseByCode(string code);
        Task<BaseResponse<LanguageCourse>> GetCourseById(int id);

        Task<BaseResponse<bool>> AddModule(int courseId, ModuleLessons moduleOfLessons);
        Task<BaseResponse<bool>> DeleteModule(int courseId, ModuleLessons moduleOfLessons);

        Task<BaseResponse<IEnumerable<LanguageCourse>>> GetAllCourses();

    }
}
