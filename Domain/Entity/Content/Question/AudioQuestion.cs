using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class AudioQuestion : BaseQuestion
    {
        public string AudioUrl { get; set; }

        public AudioQuestion(string audioUrl, string text, string rightAnswer, TypeQuestion type) 
            : base(text, rightAnswer, type)
        {
            AudioUrl = audioUrl;
        }
    }
}
