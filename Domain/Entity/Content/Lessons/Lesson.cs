using Domain.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entity.Content.Lessons
{
    public class Lesson : BaseEntity 
    {
        public string? Title { get; set; }
        [NotMapped]
        public int CountQuestion{ 
            get { return LessonQuestions.Count(); }
        }
        public bool IsAvailable { get; set; } 

        public int CourseModuleId { get; set; }
        [JsonIgnore]
        public CourseModule? CourseModules { get; set; }

        public ICollection<Theory> TheoryBlock {  get; set; }  = new List<Theory>();
        public ICollection<LessonQuestion> LessonQuestions { get; set; } = new List<LessonQuestion>();
       
        public Lesson() { }
        public Lesson(string title, bool isAvailable, int courseModuleId)
        {
            Title = title;
            IsAvailable = isAvailable;
            CourseModuleId = courseModuleId;
        }
    }
}
