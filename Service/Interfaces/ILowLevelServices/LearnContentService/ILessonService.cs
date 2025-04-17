using Common.Response;
using Domain.Entity.Content.Lessons;

namespace Service.Interfaces.ILowLevelServices.LearnContentService
{
    public interface ILessonService
    {
        Task<BaseResponse<IEnumerable<Lesson>>> GetLessons(int moduleId);
        Task<BaseResponse<Lesson>> ChangeAvailable(int lessonId);
    }
}
