using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class PictureQuestion : BaseQuestion
    {
        public string? ImagePath { get; set; }

        public PictureQuestion() { }
        public PictureQuestion(string imagePath, string questionText, QuestionType QuestionType, AnswerType answerType) : base(questionText, QuestionType, answerType)
        {
            ImagePath = imagePath;
        }
    }
}
