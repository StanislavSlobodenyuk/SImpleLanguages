using Domain.Entity.Base;

namespace Domain.Entity.Content.Question.Answer
{
    public class RightAnswer : BaseQuestionReference
    {
        public string? Answer { get; set; }

        public RightAnswer() { }
        public RightAnswer(string answer)
        {
            Answer = answer;
        }
    }
}
