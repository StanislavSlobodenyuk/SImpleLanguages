using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Lessons;
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public abstract class BaseQuestion : BaseEntity
    {
        public string? QuestionText { get; set; }
        public QuestionType Type { get; private set; }


        public int LessonId { get; private set; }
        public Lesson? Lesson { get; private set; }

        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();
        public ICollection<QuestionImage> QuestionImages { get; private set; } = new List<QuestionImage>();

        protected BaseQuestion() {}
        protected BaseQuestion(string? questionText, QuestionType type)
        {
            QuestionText = questionText;
            Type = type;
        }
    }
}

// Базовий клас для усіх видів уроків 

