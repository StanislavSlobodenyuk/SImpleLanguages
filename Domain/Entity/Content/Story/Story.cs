

using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;
using Domain.Entity.User.UserProgress.TaskResult;

namespace Domain.Entity.Content.StoryContent
{
    public class Story : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string StoryText { get; set; } = string.Empty;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public ICollection<UserStoryResult> UserResults { get; set; } = new List<UserStoryResult>();
    }
}
