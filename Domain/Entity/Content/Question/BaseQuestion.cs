using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Lessons;
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public abstract class BaseQuestion : BaseEntity
    {
        public string? QuestionText { get; set; }
        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();
        public ICollection<QuestionImage> QuestionImages { get; private set; } = new List<QuestionImage>();

        protected BaseQuestion() {}
        protected BaseQuestion(string? questionText)
        {
            QuestionText = questionText;
        }
    }
}

// Базовий клас для усіх видів уроків 

