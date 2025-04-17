using Common.Response;
using Domain.Entity.User.UserProgress;

namespace Service.Interfaces.ILowLevelServices.ProgressService
{
    public interface IUserAchievementService
    {
        Task<BaseResponse<IEnumerable<UserAchievement>>> GetUserAchievement(string userId);
    }
}
