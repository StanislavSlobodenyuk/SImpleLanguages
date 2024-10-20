using Domain.Entity.Base;
using Domain.Entity.Content.Lessons;
using Domain.Enum;

namespace Domain.Entity.Content.Metadata.Course
{
    public class LanguageCourse : BaseEntity
    {
        public string? Name { get; set; }
        public LanguageLevel Difficult { get; set; }
        public string? Description { get; set; }
        public LanguageName Language {  get; private set; }
        public string? IconPath { get; set; }
        public float Progres {  get; private set; } = 0f;

        public ICollection<CourseModule> CourseModules { get; private set; } = new List<CourseModule>();

        public LanguageCourse(string name, string description, LanguageName language, LanguageLevel difficult, string iconPath)
        {
            Name = name;
            Description = description;
            Language = language;
            Difficult = difficult;
            IconPath = iconPath;
        }
    }
}
