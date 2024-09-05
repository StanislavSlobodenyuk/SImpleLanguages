using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class Lesson : BaseEntity 
    {
        public LanguageLevel Difficulty { get; private set; }
        public int ModuleLessonsId { get; private set; }
        public ModuleLessons? ModuleLessons { get; private set; }

        public int ImageId { get;  private set; }
        public MyImage? Image { get; set; }

        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();

        public Lesson(int moduleLessonsId, int imageId)
        {
            ModuleLessonsId = moduleLessonsId;
            ImageId = imageId;
        }
    }
}
