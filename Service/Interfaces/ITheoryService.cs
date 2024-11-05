using Common.Response;
using Domain.Entity.Content.Lessons;

namespace Service.Interfaces
{
    public interface ITheoryService
    {
        Task<BaseResponse<IEnumerable<Theory>>> GetTheories(int lessonId);
    }
}
