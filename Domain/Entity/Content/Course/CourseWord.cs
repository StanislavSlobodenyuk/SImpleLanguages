
using Domain.Entity.Base;
using Domain.Entity.Content.CourseContent;
using Domain.Enum;

namespace Domain.Entity.Content
{
    public class CourseWord : BaseEntity
    {
        public string Word { get; set; } = string.Empty;

        public Course Course { get; set; } = new Course();
        public int CourseId { get; set; }

        public CourseWord() { }

        public CourseWord(string word) 
        {
            Word = word;
        }
    }
}
