
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class TranslateQuestion : BaseQuestion
    {
        public string? Sentence { get; set; }
        public string? SentenceTranslate { get; set; }

        public TranslateQuestion(string? sentence, string? sentenceTranslate, string text, string rightAnswer, TypeQuestion type)
            : base(text, rightAnswer, type)
        {
            Sentence = sentence;
            SentenceTranslate = sentenceTranslate;
        }
    }
}
