using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces.LearnContent
{
    public interface ITheoryRepository : IBaseRepository<Theory>
    {
        public Task<IEnumerable<Theory>> GetTheories(int lessonId);


    }
}
