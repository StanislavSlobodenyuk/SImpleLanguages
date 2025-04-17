using Domain.Entity.User.UserProfile;

namespace Dal.Interfaces.UserProfile
{
    public interface IUserSociableRepository : IBaseRepository<UserSociable>
    {
        //  IBaseRepository realese CRUD logic

        Task<IEnumerable<UserSociable>> GetAllUserSociables(string userId);
    }
}
