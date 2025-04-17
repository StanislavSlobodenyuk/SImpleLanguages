using Dal.Interfaces.UserProgress;
using Domain.Entity.User.UserProgress;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.UserProgress
{
    public class UserAchievementRepository : IUserAchievementRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAchievementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserAchievement>> GetUserAchievements(string userId)
        {
            return await _context.UserAchievements
                .Where(x => x.UserId == userId)
                .ToArrayAsync();
        }

        public async Task AddAchievementToUser(int achievementId, string userId)
        {
            var existAchievement = await _context.Achievements.FindAsync(achievementId);
            var existUser = await _context.Users.FindAsync(userId);

            if (existUser == null)
                throw new InvalidOperationException($"User with ID {userId} not found.");

            if (existAchievement == null)
                throw new InvalidOperationException($"Achievement with ID {achievementId} not found.");

            // check dublicate

            var alreadyAssigned = await _context.UserAchievements
                .AnyAsync(ua => ua.UserId == userId && ua.AchievementId == achievementId);

            if (alreadyAssigned)
                return;

            var newUserAchievement = new UserAchievement
            {
                AchievementId = achievementId,
                UserId = userId,
                DateEarned = DateTime.UtcNow,
            };

            await _context.UserAchievements.AddAsync(newUserAchievement);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
