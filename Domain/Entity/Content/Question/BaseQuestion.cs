using Domain.Entity.Base;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Image;
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class BaseQuestion : BaseEntity
    {
        public QuestionType Type { get; private set; }

        public int LessonId { get; private set; }
        public Lesson? Lesson { get; private set; }

        public ICollection<QuestionImage> QuestionImages { get; private set; } = new List<QuestionImage>();

        public BaseQuestion(QuestionType type)
        {
            Type = type;
        }
    }
}

// Базовий клас для усіх видів уроків 
