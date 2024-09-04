using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Lessons;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Content.Question
{
    public abstract class BaseQuestion : BaseEntity
    {
        public QuestionType Type { get; private set; }

        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();
        public ICollection<QuestionImage> QuestionImages { get; private set; } = new List<QuestionImage>();

        protected BaseQuestion() {}
        protected BaseQuestion(QuestionType type)
        {
            Type = type;
        }
    }
}

// Базовий клас для усіх видів уроків 
