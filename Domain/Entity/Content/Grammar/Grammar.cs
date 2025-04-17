using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;
using Domain.Entity.User.UserProgress.TaskResult;

namespace Domain.Entity.Content.GrammarContent
{
    public class Grammar : BaseContentCourse
    {
        public string Title { get; set; } = string.Empty;

        public ICollection<UserGrammarResult> GrammarResults { get; set; } = new List<UserGrammarResult>();
    }
}
