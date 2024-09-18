
using Domain.Entity.Base;
using Domain.Entity.Content.Image;

namespace Domain.Entity.Content.Lessons
{
    public class Lecture : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int LessonId { get; set; }
        public Lesson? lesson { get; set; }

        public ICollection<LectureImage> LectureImages { get; set; } = new List<LectureImage>();

        public Lecture(string? title, string? content)
        {
            Title = title;
            Content = content;
        }
    }
}
