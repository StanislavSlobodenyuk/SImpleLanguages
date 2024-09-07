using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public abstract class BaseQuestion : BaseEntity
    {
        public string? Text { get; set; }
        public QuestionType Type { get; private set; }

        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();
        public ICollection<QuestionImage> QuestionImages { get; private set; } = new List<QuestionImage>();

        protected BaseQuestion() {}
        protected BaseQuestion(string? text, QuestionType type)
        {
            Text = text;
            Type = type;
        }
    }
}

// Базовий клас для усіх видів уроків 
