using Domain.Entity.Content.Achievments;

namespace Dal.Interfaces.LearnContent
{
    public interface IAchievementRepository : IBaseRepository<Achievement>
    {
        //  get create update delete наследуются с базового 

        Task<IEnumerable<Achievement>> GetAchievements();
        Task SaveChangeAsync();
    }
}
