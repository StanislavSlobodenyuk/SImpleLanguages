
using Domain.Entity.Base;
using Domain.Entity.Content.Image;

namespace Domain.Entity.Content.Lessons
{
    public class LectureBlock : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int LessonId { get; private set; }
        public Lesson? lesson { get; private set; }

        public ICollection<LectureImage> LectureImages { get; set; } = new List<LectureImage>();

        public LectureBlock(string? title, string? content)
        {
            Title = title;
            Content = content;
        }
    }
}
