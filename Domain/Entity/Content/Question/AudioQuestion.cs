using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class AudioQuestion : BaseQuestion
    {
        public string? AudioPath { get; set; }

        public AudioQuestion() { }
        public AudioQuestion(string audioPath, string questionText, QustionType QuestionType, AnswerType answerType) : base(questionText, QuestionType, answerType)
        {
            AudioPath = audioPath;
        }
    }
}
