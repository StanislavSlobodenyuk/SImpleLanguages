using Common.Enum;
using Common.Response;
using Dal.Interfaces.LearnContent;
using Domain.Entity.Content.Achievments;
using Service.Interfaces.ILowLevelServices.LearnContentService;

namespace Service.Implementations.LowLevelServices.LearnContentServices
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;

        public AchievementService(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }

        public async Task<BaseResponse<IEnumerable<Achievement>>> GetAchievements()
        {
            var achievement = await _achievementRepository.GetAchievements();

            if (achievement == null)
            {
                return new BaseResponse<IEnumerable<Achievement>>()
                {
                    Data = null,
                    Description = "Achievement is not found",
                    StatusCode = MyStatusCode.NotFound
                };
            }

            return new BaseResponse<IEnumerable<Achievement>>()
            {
                Data = achievement,
                Description = "Success",
                StatusCode = MyStatusCode.OK
            };
        }

        public async Task<BaseResponse<Achievement>> GetAchievement(int id)
        {
            if (id <= 0)
            {
                return new BaseResponse<Achievement>()
                {
                    Data = null,
                    Description = $"id <= 0 ",
                    StatusCode = MyStatusCode.BadRequest
                };
            }

            var newAchievement = await _achievementRepository.GetById(id);

            if (newAchievement == null)
            {
                return new BaseResponse<Achievement>()
                {
                    Data = null,
                    Description = $"Achievement with {id} not found",
                    StatusCode = MyStatusCode.NotFound
                };
            }

            return new BaseResponse<Achievement>
            {
                Data = newAchievement,
                Description = "Success",
                StatusCode = MyStatusCode.OK
            };
        }
        public async Task<BaseResponse<bool>> CreateAchievement(Achievement achievement)
        {
            if (achievement == null)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = $"Achievment is null",
                    StatusCode = MyStatusCode.BadRequest
                };
            }

            var result = await _achievementRepository.Create(achievement);

            if (result == false)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = $"Achievement not create server error",
                    StatusCode = MyStatusCode.InternalServerError
                };
            }

            return new BaseResponse<bool>()
            {
                Data = true,
                Description = $"Success",
                StatusCode = MyStatusCode.OK
            };
        }
        public async Task<BaseResponse<bool>> UpdateAchievement(Achievement achievement)
        {
            if (achievement == null)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = $"Achievment is null",
                    StatusCode = MyStatusCode.BadRequest
                };
            }

            var result = await _achievementRepository.Update(achievement);

            if (result == false)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = $"Achievement not update.",
                    StatusCode = MyStatusCode.InternalServerError
                };
            }

            return new BaseResponse<bool>()
            {
                Data = true,
                Description = $"Success",
                StatusCode = MyStatusCode.OK
            };
        }
        public async Task<BaseResponse<bool>> DeleteAchievement(Achievement achievement)
        {
            if (achievement == null)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = $"Achievment is null",
                    StatusCode = MyStatusCode.BadRequest
                };
            }

            var result = await _achievementRepository.Delete(achievement);

            if (result == false)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = $"Achievement not create server error",
                    StatusCode = MyStatusCode.InternalServerError
                };
            }

            return new BaseResponse<bool>()
            {
                Data = true,
                Description = $"Success",
                StatusCode = MyStatusCode.OK
            };
        }
    }
}
