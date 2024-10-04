using Domain.Entity.Base;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Domain.Entity.Content.Lessons
{
    public class Lesson : BaseEntity 
    {
        public string? Title { get; set; }
        public bool IsAvailable { get; set; } 
        public string? IconPath { get; set; }


        public int ModuleLessonsId { get; set; }
        public CourseModule? CourseModules { get; set; }

        public ICollection<LectureBlock> LectureBlocks {  get; set; }  = new List<LectureBlock>();
        public ICollection<LessonQuestion> LessonQuestions { get; set; } = new List<LessonQuestion>();

        public Lesson() { } 
        public Lesson(string title, bool isAvailable, string iconPath)
        {
            Title = title;
            IsAvailable = isAvailable;
            IconPath = iconPath;
        }
    }
}
