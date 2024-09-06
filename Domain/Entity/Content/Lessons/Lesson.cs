using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class Lesson : BaseEntity 
    {
        public string Title { get; set; }
        public LanguageLevel Difficulty { get; private set; }
        public bool IsAvailable { get; set; }
        public int ModuleLessonsId { get; set; }
        public ModuleLessons? ModuleLessons { get; set; }

        public int ImageId { get; set; }
        public MyImage? Image { get; set; }

        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();

        public Lesson(string title, bool isAvailable, LanguageLevel difficulty, int moduleLessonsId, int imageId)
        {
            Title = title;
            IsAvailable = isAvailable;
            ImageId = imageId;
            Difficulty = difficulty;
            ModuleLessonsId = moduleLessonsId;
        }
    }
}
