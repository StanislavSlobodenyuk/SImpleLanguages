
namespace Domain.Entity.Content.Question
{
    public class TranslateQuestion : BaseQuestion
    {
        public string? Sentence { get; set; }
        public string? SentenceTranslate { get; set; }

        public TranslateQuestion(string? sentence, string? sentenceTranslate, string text) : base(text)
        {
            Sentence = sentence;
            SentenceTranslate = sentenceTranslate;
        }
    }
}
