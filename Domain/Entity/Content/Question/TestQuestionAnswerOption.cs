
using Domain.Entity.Base;

namespace Domain.Entity.Content.Question
{
    public class TestQuestionAnswerOption : BaseEntity
    {
        public string? AnswerOptionText { get; private set; }

        public int TestQuestionId { get; private set; }
        public TestQuestion? TestQuestion { get; private set; }

        public TestQuestionAnswerOption(int testQuestionId, string? answerOptionText)
        {
            TestQuestionId = testQuestionId;
            AnswerOptionText = answerOptionText;
        }
    }
}
