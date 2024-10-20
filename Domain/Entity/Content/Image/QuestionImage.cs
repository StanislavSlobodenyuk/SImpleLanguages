using Domain.Entity.Base;
using Domain.Entity.Content.Question;

namespace Domain.Entity.Content.Image
{
    public class QuestionImage : BaseEntity
    {
        public int ImageId { get; set; }
        public MyImage? Image { get; set; }
        
        public int TestQuestionId { get; set; }
        public  TestQuestion? TestQuestion { get; set; }

        public int AudioQuestionId { get; set; }
        public AudioQuestion? AudioQuestion { get; set; }

        public int TranslateQuestionId { get; set; }
        public TranslateQuestion? TranslateQuestion { get; set; }
    }
}
