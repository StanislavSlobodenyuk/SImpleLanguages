using Domain.Entity.Base;
using Domain.Enum;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entity.Content.Question
{
    public class AudioQuestion : BaseQuestion
    {
        public string? RightAnswer { get; private set; }
        public string? AudioUrl { get; private set; }

        public AudioQuestion(string rightAnswer, string audioUrl, string text) : base(text)
        {
            RightAnswer = rightAnswer;
            AudioUrl = audioUrl;
        }

        public void UpdateRightAnswer(string? rightAnswer)
        {
            if (!string.IsNullOrEmpty(rightAnswer))
            {
                RightAnswer = rightAnswer;
            }
        }
        public void UpdateAudioUrl(string? audioUrl)
        {
            if (!string.IsNullOrEmpty(audioUrl))
            {
                AudioUrl = audioUrl;
            }
        }
    }
}
