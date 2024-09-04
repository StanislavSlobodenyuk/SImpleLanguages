using Domain.Entity.Base;
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class AudioQuestion : BaseQuestion
    {
        public string? RightAnswer { get; private set; }
        public string? AudioUrl { get; private set; }

        public AudioQuestion(string? rightAnswer, string audioUrl, QuestionType type) : base(type)
        {
            RightAnswer = rightAnswer;
            AudioUrl = audioUrl;
        }
    }
}
