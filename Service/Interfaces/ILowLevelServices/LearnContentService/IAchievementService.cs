using Common.Response;
using Domain.Entity.Content.Achievments;

namespace Service.Interfaces.ILowLevelServices.LearnContentService
{
    public interface IAchievementService
    {
        Task<BaseResponse<IEnumerable<Achievement>>> GetAchievements();
        Task<BaseResponse<Achievement>> GetAchievement(int id);
        Task<BaseResponse<bool>> CreateAchievement(Achievement achievement);
        Task<BaseResponse<bool>> UpdateAchievement(Achievement achievement);
        Task<BaseResponse<bool>> DeleteAchievement(Achievement achievement);
    }
}
