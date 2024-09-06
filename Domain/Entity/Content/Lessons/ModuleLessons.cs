
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class ModuleLessons : BaseContent
    {
        public string? Description { get; private set; }
        public bool? IsAvailable { get; set; } = false;

        public ICollection<Lesson> Lessons { get; private set; } = new List<Lesson>();

        public ModuleLessons() { }

        public ModuleLessons(string description, bool isAvailable, string title)
            : base(title)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            IsAvailable = isAvailable;
        }
    }
}
