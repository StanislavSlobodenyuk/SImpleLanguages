

using Common.Response;
using Domain.Entity.Content.Lessons;

namespace Service.Interfaces
{
    public interface IModuleLessonService 
    {
        Task<BaseResponse<CourseModule>> CreateModule(string title, string description, bool isAvailable);
        Task<BaseResponse<bool>> DeleteModule(int moduleId);
        Task<BaseResponse<CourseModule>> GetModule(int moduleId);
        Task<BaseResponse<CourseModule>> ChangeAvailableModule(int moduleId, bool isAvailable);

        Task<BaseResponse<Lesson>> AddLesson(int moduleId, Lesson lesson);
        Task<BaseResponse<bool>> DeleteLesson(int moduleId, Lesson lesson);
        Task<BaseResponse<bool>> DeleteAllLesson (int moduleId, List<Lesson> lessons);

        public Task<BaseResponse<IEnumerable<Lesson>>> GetAllLessonThisModule(int moduleId, Lesson lesson);

    }
}
