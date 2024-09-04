using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class Lesson : BaseEntity 
    {
        public LanguageLevel Difficulty { get; private set; }
        public int ModuleOfLessonsId { get; private set; }
        public ModuleOfLessons? ModuleOfLessons { get; private set; }

        public int ImageId { get;  private set; }
        public MyImage? Image { get; set; }

        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();

        public Lesson(int moduleOfLessonsId, int imageId)
        {
            ModuleOfLessonsId = moduleOfLessonsId;
            ImageId = imageId;
        }
    }
}
