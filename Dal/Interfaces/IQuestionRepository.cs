
using Domain.Entity.Content.Question;

namespace Dal.Interfaces
{
    public interface IQuestionRepository : IBaseRepository<BaseQuestion>
    {
        Task<IEnumerable<BaseQuestion>> GetQuestions(int lessonId);
    }
}
