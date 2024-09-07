
using Domain.Entity.Base;

namespace Domain.Entity.Content.Question
{
    public class TestAnswerOption : BaseEntity
    {
        public string? Text { get; set; }

        public int TestQuestionId { get; private set; }
        public TestQuestion? TestQuestion { get; private set; }
        public TestAnswerOption(string? text)
        {
            Text = text;
        }
    }
}
