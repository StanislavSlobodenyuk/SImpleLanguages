using Domain.Entity.Content.CourseContent;
using System.Text.Json.Serialization;

namespace Domain.Entity.Content.Lessons
{
    public class CourseModule : BaseContentCourse
    {
        public string? Title { get; set; }
        public string? PathToMap { get; set; }
        public bool IsAvailable { get; set; } = true;

        public ICollection<Lesson> Lessons { get;  set; } = new List<Lesson>();

        public CourseModule() { }
        public CourseModule(string title, bool isAvailable, string pathToMap)
        {
            Title = title;
            IsAvailable = isAvailable;
            PathToMap = pathToMap;
        }
    }
}
