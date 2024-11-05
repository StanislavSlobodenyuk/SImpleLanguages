
using Common.Response;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;

namespace Service.Interfaces
{
    public interface ILessonService
    {
        Task<BaseResponse<IEnumerable<Lesson>>> GetLessons(int moduleId);
        Task<BaseResponse<Lesson>> ChangeAvailable(int lessonId);
    }
}
