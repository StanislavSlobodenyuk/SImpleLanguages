
using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;
using Domain.Entity.Content.StoryContent;

namespace Domain.Entity.User.UserProgress.TaskResult
{
    public class UserStoryResult : UserTaskResultBase
    {
        public int StoryId { get; set; }
        public Story Story { get; set; } = new Story();
    }
}
