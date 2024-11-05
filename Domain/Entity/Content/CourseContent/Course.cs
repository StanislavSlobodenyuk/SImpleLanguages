using Domain.Entity.Base;
using Domain.Entity.Content.Lessons;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Content.CourseContent
{
    public class Course : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; } = null;
        public LanguageLevel Level { get; set; } = LanguageLevel.Elementary;
        public LanguageName Language { get; set; }
        [NotMapped]
        public int LessonCount => CourseModules?.Sum(m => m.Lessons.Count) ?? 0;
        public decimal Cost { get; set; } = 0m;
        public string? ImgPath { get; set; }
        public bool InDevelopment { get; set; } = false;

        public ICollection<CourseModule> CourseModules { get; private set; } = new List<CourseModule>();

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
