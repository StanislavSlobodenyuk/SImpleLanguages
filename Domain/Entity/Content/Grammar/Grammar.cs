using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;
using Domain.Entity.User.UserProgress.TaskResult;

namespace Domain.Entity.Content.GrammarContent
{
    public class Grammar : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string RuleText { get; set; } = string.Empty;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public ICollection<UserGrammarResult> UserResults { get; set; } = new List<UserGrammarResult>();

    }
}
