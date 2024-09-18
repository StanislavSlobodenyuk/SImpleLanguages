
using Common.Response;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;

namespace Service.Interfaces
{
    public interface ILanguageCourseService
    {
        Task<BaseResponse<LanguageCourse>> CreateCourse(string name, string description, LanguageName languageName, LanguageLevel difficult, string iconPath);
        Task<BaseResponse<bool>> DeleteCourse(int courseID);

        Task<BaseResponse<LanguageCourse>> GetCourseByName(LanguageName languageName);
        Task<BaseResponse<LanguageCourse>> GetCourseById(int id);

        Task<BaseResponse<ModuleLessons>> AddModule(int courseId, ModuleLessons moduleOfLessons);
        Task<BaseResponse<bool>> DeleteModule(int courseId, ModuleLessons moduleOfLessons);
        Task<BaseResponse<IEnumerable<ModuleLessons>>> GetAllModulesThisCourse(int courseId);


        Task<BaseResponse<IEnumerable<LanguageCourse>>> GetAllCourses();

    }
}
