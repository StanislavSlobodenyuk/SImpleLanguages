using Domain.Entity.Content.Lessons;

namespace Dal.Interfaces
{
    public interface ITheoryRepository : IBaseRepository<Theory>
    {
        public Task<IEnumerable<Theory>> GetTheories(int lessonId);
    }
}
