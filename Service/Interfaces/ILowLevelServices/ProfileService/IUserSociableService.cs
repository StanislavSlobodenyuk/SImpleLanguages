using Common.Response;
using Domain.Entity.User.UserProfile;

namespace Service.Interfaces.ILowLevelServices.ProfileService
{
    public interface IUserSociableService
    {
        Task<BaseResponse<IEnumerable<UserSociable>>> GetUserSociables(string userId);
        Task<BaseResponse<UserSociable>> GetSociable(int id);
        Task<BaseResponse<bool>> CreateSociable(UserSociable sociable);
        Task<BaseResponse<bool>> UpdateSociabble(UserSociable sociable);
        Task<BaseResponse<bool>> DeleteSociable(UserSociable sociable);
    }
}
