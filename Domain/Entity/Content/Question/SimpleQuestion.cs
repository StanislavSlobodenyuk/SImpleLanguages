using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Content.Question
{
    public class SimpleQuestion : BaseQuestion
    {
        public SimpleQuestion() { }
        public SimpleQuestion(string questionText, QuestionType questionType, AnswerType answerType)
         : base(questionText, questionType, answerType)
        {
        }
    }
}
