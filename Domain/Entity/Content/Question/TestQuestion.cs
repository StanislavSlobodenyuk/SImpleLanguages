
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Content.Question
{
    public class TestQuestion : BaseQuestion
    {
        public IEnumerable<TestAnswerOption> AnswerOptions { get; set; } = new List<TestAnswerOption>();
        public TestQuestion(string text, string rightAnswer, TypeQuestion type) : base(text, rightAnswer, type)
        {
        }
    }
}
