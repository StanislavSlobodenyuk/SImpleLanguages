
using Domain.Entity.User.UserProfile;
using Domain.Entity.User.UserProgress;
using Domain.Entity.User.UserProgress.TaskResult;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entity.User
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string UserIcon { get; set; } = string.Empty;
        public LanguageName NativeLanguage { get; set; }

        public ICollection<UserSociable> UserSociables { get; set; } = new List<UserSociable>();

        public ICollection<CourseUserProgress> CourseUserProgresses { get; set; } = new List<CourseUserProgress>();

        public ICollection<UserWord> UserWords { get; set; } = new List<UserWord>();

        public ICollection<UserLessonResult> LessonResults { get; set; } = new List<UserLessonResult>();
        public ICollection<UserStoryResult> StoryResults { get; set; } = new List<UserStoryResult>();
        public ICollection<UserGrammarResult> GrammarResults { get; set; } = new List<UserGrammarResult>();

        public ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
    }
}
