using Domain.Entity.Base;
using Domain.Entity.Content.DictionaryContent;

namespace Domain.Entity.User.UserProgress
{
    public class UserWord : BaseEntity
    {
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public bool IsLearned { get; set; } = false;
        public int RepetitionCount { get; set; } = 0;
        public DateTime? LastReviewed { get; set; }

        public User User { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;
        public MyDictionary Dictionary { get; set; } = null!;
        public int DictionaryId { get; set; }
    }
}
