
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class CourseModule : BaseContent
    {
        public string? Title { get; set; }
        public bool? IsAvailable { get; set; } = false;
        public string? PathToMap { get; set; }

        public ICollection<Lesson> Lessons { get;  set; } = new List<Lesson>();

        public CourseModule() { }

        public CourseModule(string title, bool isAvailable, string pathToMap)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            IsAvailable = isAvailable;
            PathToMap = pathToMap ?? throw new ArgumentNullException(nameof(pathToMap));
        }
    }
}
