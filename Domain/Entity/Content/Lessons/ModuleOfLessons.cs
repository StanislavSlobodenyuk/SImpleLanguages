
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class ModuleOfLessons : BaseContent
    {
        public string? Description { get; private set; }
        public ICollection<Lesson> Lessons { get; private set; } = new List<Lesson>();

        public ModuleOfLessons() { }

        public ModuleOfLessons(string description, string title, int languageId)
            : base(title, languageId)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
