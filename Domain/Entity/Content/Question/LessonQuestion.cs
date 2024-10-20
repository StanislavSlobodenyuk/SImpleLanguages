
using Domain.Entity.Base;
using Domain.Entity.Content.Lessons;


namespace Domain.Entity.Content.Question
{
    public class LessonQuestion : BaseEntity
    {
        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }

        public int TestQuestionId { get; set; }
        public TestQuestion? TestQuestion { get; set; }

        public int AudioQuestionId { get; set; }
        public AudioQuestion? AudioQuestion { get; set; }

        public int TranslateQuestionId { get; set; }
        public TranslateQuestion? TranslateQuestion { get; set; }
    }
}
