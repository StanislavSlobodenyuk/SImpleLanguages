using Domain.Entity.Base;

namespace Domain.Entity.Content.Question.Answer
{
    public class AnswerOption : BaseQuestionReference
    {
        public string? Option { get; set; }

        public AnswerOption() { }
        public AnswerOption(string option)
        {
            Option = option;
        }
    }
}
