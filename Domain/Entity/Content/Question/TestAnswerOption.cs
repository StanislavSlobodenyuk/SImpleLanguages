
using Domain.Entity.Base;

namespace Domain.Entity.Content.Question
{
    public class TestAnswerOption : BaseEntity
    {
        public string? OptionText { get; set; }

        public int TestQuestionId { get; private set; }
        public TestQuestion? TestQuestion { get; private set; }

        public TestAnswerOption(string? optionText)
        {
            OptionText = optionText;
        }
    }
}
