using Common.Response;
using Domain.Entity.Content.Lessons;

namespace Service.Interfaces.ILowLevelServices.LearnContentService
{
    public interface ITheoryService
    {
        Task<BaseResponse<IEnumerable<Theory>>> GetTheories(int lessonId);
    }
}
