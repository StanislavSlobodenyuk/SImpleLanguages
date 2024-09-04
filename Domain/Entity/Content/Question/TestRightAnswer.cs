using Domain.Entity.Base;

namespace Domain.Entity.Content.Question
{
    public class TestRightAnswer : BaseEntity
    {
        public string? RightAnswer { get; private set; }

        public TestQuestion? TestQuestion {  get; private set; } 
        public int TestQuestionId { get; private set; }

        public TestRightAnswer(int testQuestionId, string? rightAnswer)
        {
            TestQuestionId = testQuestionId;
            RightAnswer = rightAnswer ?? throw new ArgumentNullException(nameof(rightAnswer));
        }
    }
}
