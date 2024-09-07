using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Dal.Interfaces.QuestionRepository
{
    public interface ITestQuestionRepository
    {
        Task<TestQuestion?> CreateTestQuestion(TestQuestion testQuestion, IEnumerable<TestAnswerOption> answerOptions, TestRightAnswer rightAnswer);

        Task<TestQuestion?> UpdateQuestion(int testQuestionId, string text);
        Task<TestQuestion?> UpdateAnswerOptions(int testQuestionId, IEnumerable<TestAnswerOption> answerOptions);
        Task<TestQuestion?> UpdateRightAnswer(int testQuestionId, TestRightAnswer rightAnswer);
    }
}
