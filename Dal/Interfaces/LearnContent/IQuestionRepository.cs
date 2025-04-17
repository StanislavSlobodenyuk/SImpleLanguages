using Domain.Entity.Content.Question;

namespace Dal.Interfaces.LearnContent
{
    public interface IQuestionRepository : IBaseRepository<BaseQuestion>
    {
        Task<IEnumerable<object>> GetQuestions(int lessonId);
    }
}
