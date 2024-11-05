
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Content.Question
{
    public class TestQuestion : BaseQuestion
    {
        public TestQuestion() { }
        public TestQuestion(string questionText, QustionType questionType, AnswerType answerType)
         : base(questionText, questionType, answerType)
        {
        }
    }
}
