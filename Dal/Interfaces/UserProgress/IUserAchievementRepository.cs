using Domain.Entity.User.UserProgress;

namespace Dal.Interfaces.UserProgress
{
    public interface IUserAchievementRepository 
    {
        Task<IEnumerable<UserAchievement>> GetUserAchievements(string userId);
        Task AddAchievementToUser(int achievementId, string userId);
        Task SaveChangeAsync();
    }
}
