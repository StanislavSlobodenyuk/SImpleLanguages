using Domain.Entity.Base;
using Domain.Entity.Content.Question;


namespace Domain.Entity.Content.Lessons
{
    public class LessonQuestion : BaseQuestionReference
    {
        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
