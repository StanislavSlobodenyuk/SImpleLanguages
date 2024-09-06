

using Common.Response;
using Domain.Entity.Content.Lessons;

namespace Service.Interfaces
{
    public interface IModuleLessonsService 
    {
        Task<BaseResponse<ModuleLessons>> CreateModule(string title, string description, bool isAvailable);
        Task<BaseResponse<bool>> DeleteModule(int moduleId);
        Task<BaseResponse<ModuleLessons>> GetModule(int moduleId);
        Task<BaseResponse<ModuleLessons>> ChangeAvailableModule(int moduleId, bool isAvailable);

        Task<BaseResponse<Lesson>> AddLesson(int moduleId, Lesson lesson);
        Task<BaseResponse<bool>> DeleteLesson(int moduleId, Lesson lesson);
        Task<BaseResponse<bool>> DeleteAllLesson (int moduleId, List<Lesson> lessons);

        public Task<BaseResponse<IEnumerable<Lesson>>> GetAllLessonThisModule(int moduleId, Lesson lesson);

    }
}
