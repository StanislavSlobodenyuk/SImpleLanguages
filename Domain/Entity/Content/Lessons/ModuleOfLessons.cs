
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class ModuleOfLessons : BaseContent
    {
        public string? Description { get; private set; }
        public bool? IsAvailable { get; set; } = false;

        public ICollection<Lesson> Lessons { get; private set; } = new List<Lesson>();

        public ModuleOfLessons() { }

        public ModuleOfLessons(string description, int languageId, bool isAvailable, string title, int languageCourseId)
            : base(title, languageCourseId)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            IsAvailable = isAvailable;
        }
    }
}
