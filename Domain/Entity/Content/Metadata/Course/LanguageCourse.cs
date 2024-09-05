using Domain.Entity.Base;
using Domain.Entity.Content;
using Domain.Entity.Content.Lessons;

namespace Domain.Entity.Content.Metadata.Course
{
    public class LanguageCourse : BaseEntity
    {
        public string? LanguageName { get; private set; }
        public string? Code { get; private set; }
        public string? IconPath { get; private set; }

        public ICollection<ModuleLessons> ModulesLessons { get; private set; } = new List<ModuleLessons>();

        public LanguageCourse(string? languageName, string? code, string? icon)
        {
            LanguageName = languageName ?? throw new ArgumentNullException(nameof(languageName));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            IconPath = icon ?? throw new ArgumentNullException(nameof(icon));
        }
        public void Update(string? languageName, string? code, string? iconPath)
        {
            if (!string.IsNullOrEmpty(languageName))
            {
                LanguageName = languageName;
            }

            if (!string.IsNullOrEmpty(code))
            {
                Code = code;
            }

            if (!string.IsNullOrEmpty(iconPath))
            {
                IconPath = iconPath;
            }
        }
    }
}
