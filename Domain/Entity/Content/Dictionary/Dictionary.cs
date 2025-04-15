
using Domain.Entity.Base;
using Domain.Entity.User.UserProgress;
using Domain.Enum;

namespace Domain.Entity.Content.DictionaryContent
{
    public class MyDictionary : BaseEntity
    {
        public string Word { get; set; } = string.Empty;
        public LanguageName language { get; set; }
        public LanguageLevel LanguageLevel { get; set;}
        public DateTime DataAdded { get; set; } = DateTime.UtcNow;

        public ICollection<CourseWord> CourseWords { get; set; } = new List<CourseWord>();
        public ICollection<UserWord> UserWords { get; set; } = new List<UserWord>();

        public MyDictionary() { }
        public MyDictionary(string word, LanguageName language, LanguageLevel languageLevel, DateTime dataAdded)
        {
            Word = word;
            this.language = language;
            LanguageLevel = languageLevel;
            DataAdded = dataAdded;
        }
    }
}
