using Domain.Entity.Content.Question;

namespace Domain.Entity.Base
{
    public abstract class BaseQuestionReference : BaseEntity
    {
        public int? TestQuestionId { get; set; }
        public TestQuestion? TestQuestion { get; set; }

        public int? AudioQuestionId { get; set; }
        public AudioQuestion? AudioQuestion { get; set; }

        public int? ImageQuestionId { get; set; }
        public ImageQuestion? ImageQuestion { get; set; }
        public int? TextQuestionId { get; set; }
        public TextQuestion? TextQuestion { get; set; }
    }
}
