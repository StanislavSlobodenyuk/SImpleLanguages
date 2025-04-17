using Common.Enum;
using Common.Response;
using Dal.Repositories.UserProgress;
using Domain.Entity.User.UserProgress;
using Service.Interfaces.ILowLevelServices.ProgressService;

namespace Service.Implementations.LowLevelServices.ProgressServices
{
    public class UserAchievementService : IUserAchievementService
    {
        private readonly UserAchievementRepository _userAchievementRepository;

        public UserAchievementService(UserAchievementRepository userAchievementRepository)
        {
            _userAchievementRepository = userAchievementRepository;
        }

        public async Task<BaseResponse<IEnumerable<UserAchievement>>> GetUserAchievement(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return new BaseResponse<IEnumerable<UserAchievement>>()
                {
                    Data = null,
                    Description = "User id is not correct",
                    StatusCode = MyStatusCode.BadRequest
                };
            }

            var userAchievement = await _userAchievementRepository.GetUserAchievements(userId);

            if (userAchievement == null)
            {
                return new BaseResponse<IEnumerable<UserAchievement>>()
                {
                    Data = null,
                    Description = "User haven`t achievements",
                    StatusCode = MyStatusCode.NotFound
                };
            }

            return new BaseResponse<IEnumerable<UserAchievement>>()
            {
                Data = userAchievement,
                Description = "Success",
                StatusCode = MyStatusCode.OK
            };
        }
    }
}
