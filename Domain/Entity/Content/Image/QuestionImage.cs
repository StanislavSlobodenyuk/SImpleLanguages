using Domain.Entity.Base;
using Domain.Entity.Content.Question;

namespace Domain.Entity.Content.Image
{
    public class QuestionImage : BaseEntity
    {
        public int ImageId { get; set; }
        public MyImage? Image { get; set; }
        
        public int QuestionId { get; set; }
        public BaseQuestion? Question { get; set; }
    }
}
