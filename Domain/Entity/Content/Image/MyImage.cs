using Domain.Entity.Base;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;

namespace Domain.Entity.Content.Image
{
    public class MyImage : BaseEntity
    {
        public string? ImagePath { get; set; }

        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }

        public ICollection<QuestionImage> QuestionImages { get; private set; } = new List<QuestionImage>();

        public MyImage(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
