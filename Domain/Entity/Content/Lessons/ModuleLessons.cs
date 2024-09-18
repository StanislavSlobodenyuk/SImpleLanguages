
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class ModuleLessons : BaseContent
    {
        public string? Title { get; private set; }
        public bool? IsAvailable { get; set; } = false;
        public string? PathToMap { get; private set; }

        public ICollection<Lesson> Lessons { get; private set; } = new List<Lesson>();

        public ModuleLessons() { }

        public ModuleLessons(string title, bool isAvailable, string pathToMap)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            IsAvailable = isAvailable;
            PathToMap = pathToMap ?? throw new ArgumentNullException(nameof(pathToMap));
        }
    }
}
