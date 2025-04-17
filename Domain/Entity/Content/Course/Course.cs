using Domain.Entity.Base;
using Domain.Entity.Content.GrammarContent;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.StoryContent;
using Domain.Entity.User.UserProgress;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Content.CourseContent
{
    public class Course : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public LanguageLevel Level { get; set; } = LanguageLevel.Elementary;
        public LanguageName Language { get; set; }
        public decimal Cost { get; set; } = 0m;
        public string? ImgPath { get; set; }
        public bool InDevelopment { get; set; } = false;

        public ICollection<CourseModule> CourseModules { get; set; } = new List<CourseModule>();
        public ICollection<Grammar> Grammars { get; set; } = new List<Grammar>();
        public ICollection<Story> Stories { get; set; } = new List<Story>();
        public ICollection<CourseWord> CourseWords { get; set; } = new List<CourseWord>();

        [NotMapped]
        public int TotalTaskCount => CourseModules?.Sum(m => m.Lessons.Count) ?? 0;

        public Course() { }

        public Course(string title, string description, LanguageName language, LanguageLevel level, string imgPath)
        {
            Title = title;
            Description = description;
            Language = language;
            Level = level;
            ImgPath = imgPath;
        }
    }
}
