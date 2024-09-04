using Domain.Entity.Base;
using Domain.Entity.Content;

namespace Domain.Entity.Content.Metadata.Course
{
    public class Course : BaseEntity
    {
        public string? LanguageName { get; private set; }
        public string? Code { get; private set; }
        public string? Icon { get; private set; }


        public ICollection<BaseContent> ModulesOfLessons { get; private set; } = new List<BaseContent>();

        public Course(string? languageName, string? code, string? icon)
        {
            LanguageName = languageName ?? throw new ArgumentNullException(nameof(languageName));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
        }
    }
}
