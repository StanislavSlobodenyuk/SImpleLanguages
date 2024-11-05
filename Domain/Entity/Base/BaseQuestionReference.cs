using Domain.Entity.Content.Question;
using System.Text.Json.Serialization;

namespace Domain.Entity.Base
{
    public abstract class BaseQuestionReference : BaseEntity
    {
        public int? TestQuestionId { get; set; }
        [JsonIgnore]
        public TestQuestion? TestQuestion { get; set; }

        public int? AudioQuestionId { get; set; }
        [JsonIgnore]
        public AudioQuestion? AudioQuestion { get; set; }

        public int? ImageQuestionId { get; set; }
        [JsonIgnore]
        public ImageQuestion? ImageQuestion { get; set; }
        public int? TextQuestionId { get; set; }
        [JsonIgnore]
        public TextQuestion? TextQuestion { get; set; }
    }
}
