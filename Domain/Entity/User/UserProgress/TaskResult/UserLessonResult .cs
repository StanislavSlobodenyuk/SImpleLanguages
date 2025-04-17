using Domain.Entity.Content.Lessons;

namespace Domain.Entity.User.UserProgress.TaskResult
{
    public class UserLessonResult : UserTaskResultBase
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } = new Lesson();
    }
}
