
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class ImageQuestion : BaseQuestion
    {
        public string? ImagePath { get; set; }

        public ImageQuestion(){}
        public ImageQuestion(string imagePath, string questionText, QustionType QuestionType, AnswerType answerType) : base(questionText, QuestionType, answerType)
        {
            ImagePath = imagePath;
        }
    }
}
