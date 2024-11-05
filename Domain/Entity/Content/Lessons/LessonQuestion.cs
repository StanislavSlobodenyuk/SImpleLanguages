using Domain.Entity.Base;
using Domain.Entity.Content.Question;
using System.Text.Json.Serialization;


namespace Domain.Entity.Content.Lessons
{
    public class LessonQuestion : BaseQuestionReference
    {
        public int LessonId { get; set; }
        [JsonIgnore]
        public Lesson? Lesson { get; set; }
    }
}
