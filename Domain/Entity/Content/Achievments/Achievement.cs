using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;
using Domain.Entity.User.UserProgress;

namespace Domain.Entity.Content.Achievments
{
    public class Achievement : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconPath { get; set; } = string.Empty;

        public bool IsCourseRelated { get; set; } = false;

        public int TargetValue { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
    }
}
