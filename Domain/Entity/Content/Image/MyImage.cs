using Domain.Entity.Base;
using Domain.Entity.Content.Lessons;

namespace Domain.Entity.Content.Image
{
    public class MyImage : BaseEntity
    {
        public string? ImagePath { get; set; }

        public ICollection<QuestionImage> QuestionImages { get; private set; } = new List<QuestionImage>();
        public ICollection<LectureImage> LectureImages { get; private set; } = new List<LectureImage>();


        public MyImage(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
