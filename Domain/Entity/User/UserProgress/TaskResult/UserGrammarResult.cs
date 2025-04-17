using Domain.Entity.Content.GrammarContent;

namespace Domain.Entity.User.UserProgress.TaskResult
{
    public class UserGrammarResult : UserTaskResultBase
    {
        public int GrammarId { get; set; }
        public Grammar Grammar { get; set; } = new Grammar();
    }
}
