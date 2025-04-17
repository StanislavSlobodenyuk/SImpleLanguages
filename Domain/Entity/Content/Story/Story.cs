

using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;
using Domain.Entity.User.UserProgress.TaskResult;

namespace Domain.Entity.Content.StoryContent
{
    public class Story : BaseContentCourse
    {
        public string Title { get; set; } = string.Empty;

        public ICollection<UserStoryResult> StoryResults { get; set; } = new List<UserStoryResult>();
    }
}
