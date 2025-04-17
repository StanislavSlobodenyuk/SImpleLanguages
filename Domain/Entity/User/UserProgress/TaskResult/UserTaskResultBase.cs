using Domain.Entity.Base;


namespace Domain.Entity.User.UserProgress.TaskResult
{
    public class UserTaskResultBase : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = new User();

        public double Score { get; set; } = 0;
        public bool IsCompleted { get; set; } = false;
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
    }
}
