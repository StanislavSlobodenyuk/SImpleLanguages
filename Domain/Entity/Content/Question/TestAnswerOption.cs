
using Domain.Entity.Base;

namespace Domain.Entity.Content.Question
{
    public class TestAnswerOption : BaseEntity
    {
        public string? Text { get; private set; }

        public int TestQuestionId { get; private set; }
        public TestQuestion? TestQuestion { get; private set; }
        public TestAnswerOption(string? text, int testQuestionId)
        {
            Text = text;
            TestQuestionId = testQuestionId;
        }
    }
}
