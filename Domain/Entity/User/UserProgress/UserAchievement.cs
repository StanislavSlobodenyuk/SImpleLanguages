using Domain.Entity.Base;
using Domain.Entity.Content.Achievments;

namespace Domain.Entity.User.UserProgress
{
    public class UserAchievement : BaseEntity
    {
        public DateTime DateEarned { get; set; } = DateTime.UtcNow;
        public bool IsEarned { get; set; } = false;

        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; } = new Achievement();

        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = new User();
    }
}
