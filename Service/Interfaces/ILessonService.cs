
using Common.Response;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;

namespace Service.Interfaces
{
    public interface ILessonService
    {
        Task<BaseResponse<Lesson>> ChangeAvailable(int lessonId);
        Task<BaseResponse<Lesson>> GetLesson(int lessonId);
    }
}
