
using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;

namespace Domain.Entity.User.UserProgress.TaskResult
{
    public class UserTaskResultBase : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; } = new User();

        public int CourseId { get; set; }
        public Course Course { get; set; } = new Course();

        public double Score { get; set; } = 0;
        public bool IsCompleted { get; set; } = false;
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
    }
}
