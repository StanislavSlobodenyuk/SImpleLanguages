using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Lessons;
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public abstract class BaseQuestion : BaseEntity
    {
        public string? Text { get; set; }

        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();
        public ICollection<QuestionImage> QuestionImages { get; private set; } = new List<QuestionImage>();

        protected BaseQuestion(string? text)
        {
            Text = text;
        }
    }
}

