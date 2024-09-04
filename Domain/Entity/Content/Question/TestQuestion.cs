
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public class TestQuestion : BaseQuestion
    {
        public string? TextQuestion {  get; private set; }

        public TestRightAnswer? RightAnswer { get; set; }
        public int RightAnswerId { get; set; }

        public ICollection<TestAnswerOption> AnswerOptions { get; set; } = new List<TestAnswerOption>();

        protected TestQuestion() { }
        public TestQuestion(string? textQuestion, int rightAnswerId, QuestionType type) : base(type)
        {
            TextQuestion = textQuestion;
            RightAnswerId = rightAnswerId;
        }
    }
}
