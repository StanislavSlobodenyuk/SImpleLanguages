using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class Lesson : BaseEntity 
    {
        public string Title { get; set; }
        public LanguageLevel Difficult { get; private set; }
        public bool IsAvailable { get; set; } 
        public string? IconPath { get; set; }

        public int ModuleLessonsId { get; set; }
        public ModuleLessons? ModuleLessons { get; set; }

        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();

        public Lesson(string title, LanguageLevel difficult, bool isAvailable, string iconPath)
        {
            Title = title;
            Difficult = difficult;
            IsAvailable = isAvailable;
            IconPath = iconPath;
        }
    }
}
