using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class TestQuestion : BaseQuestion
    {
        public string? TextQuestion {  get; private set; } 

        public TestQuestionRightAnswer? QuestionAnswer { get; set; }
        public int  TestQuestionAnwerId { get; set; }

        public ICollection<TestQuestionRightAnswer> RightAnswers { get; set; } = new List<TestQuestionRightAnswer>();
        public TestQuestion(string? textQuestion, int testQuestionAnwerId, QuestionType type) : base(type)
        {
            TextQuestion = textQuestion;
            TestQuestionAnwerId = testQuestionAnwerId;
        }
    }
}
