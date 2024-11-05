

using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class TextQuestion : BaseQuestion
    {
        public string? Text { get; set; }

        public TextQuestion()
        {
        }
        public TextQuestion(string text, string questionText, QustionType QuestionType, AnswerType answerType) : base(questionText, QuestionType, answerType)
        {
            Text = text;
        }
    }
}
