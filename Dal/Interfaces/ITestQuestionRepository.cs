
using Domain.Entity.Content.Question;

namespace Dal.Interfaces
{
    public interface ITestQuestionRepository : IBaseRepository<TestQuestion>
    {
        Task<bool> AddTestQuestion(TestQuestion testQuestion, IEnumerable<TestAnswerOption> answerOptions, TestRightAnswer rightAnswer);
        Task<bool> DeleteTestQuestion(TestQuestion testQuestion);
    }
}
