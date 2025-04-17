using Common.Enum;
using Common.Response;
using Dal.Interfaces.UserProfile;
using Domain.Entity.User.UserProfile;
using Service.Interfaces.ILowLevelServices.ProfileService;

namespace Service.Implementations.LowLevelServices.ProfileServices
{
    public class UserSociableService : IUserSociableService
    {
        private readonly IUserSociableRepository _userSociableRepository;

        public UserSociableService(IUserSociableRepository repository)
        {
            _userSociableRepository = repository;
        }

        public async Task<BaseResponse<IEnumerable<UserSociable>>> GetUserSociables(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return new BaseResponse<IEnumerable<UserSociable>>()
                {
                    Data = null,
                    Description = "User id is null or empty",
                    StatusCode = MyStatusCode.BadRequest,
                };
            }

            var sociables = await _userSociableRepository.GetAllUserSociables(userId);

            if (sociables == null)
            {
                return new BaseResponse<IEnumerable<UserSociable>>()
                {
                    Data = null,
                    Description = "Error get data.",
                    StatusCode = MyStatusCode.InternalServerError,
                };
            }

            return new BaseResponse<IEnumerable<UserSociable>>()
            {
                Data = sociables,
                Description = "Success",
                StatusCode = MyStatusCode.OK
            };
        }

        public async Task<BaseResponse<UserSociable>> GetSociable(int id)
        {
            if (id <= 0)
            {
                return new BaseResponse<UserSociable>()
                {
                    Data = null,
                    Description = "Id  <= 0",
                    StatusCode = MyStatusCode.BadRequest,
                };
            }

            var sociable = await _userSociableRepository.GetById(id);

            if (sociable == null)
            {
                return new BaseResponse<UserSociable>()
                {
                    Data = null,
                    Description = "Error get data.",
                    StatusCode = MyStatusCode.NotFound,
                };
            }

            return new BaseResponse<UserSociable>()
            {
                Data = sociable,
                Description = "Success",
                StatusCode = MyStatusCode.OK
            };
        }

        public async Task<BaseResponse<bool>> CreateSociable(UserSociable sociable)
        {
            if (sociable == null)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Sociable is null",
                    StatusCode = MyStatusCode.BadRequest,
                };
            }

            var result = await _userSociableRepository.Create(sociable);

            if (result == false)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Error add new sociable",
                    StatusCode = MyStatusCode.InternalServerError,
                };
            }

            return new BaseResponse<bool>()
            {
                Data = true,
                Description = "Success",
                StatusCode = MyStatusCode.OK
            };
        }

        public async Task<BaseResponse<bool>> UpdateSociabble(UserSociable sociable)
        {
            if (sociable == null)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Sociable is null",
                    StatusCode = MyStatusCode.BadRequest,
                };
            }

            var result = await _userSociableRepository.Update(sociable);

            if (result == false)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Error update sociable",
                    StatusCode = MyStatusCode.InternalServerError,
                };
            }

            return new BaseResponse<bool>()
            {
                Data = true,
                Description = "Success",
                StatusCode = MyStatusCode.OK
            };
        }

        public async Task<BaseResponse<bool>> DeleteSociable(UserSociable sociable)
        {
            if (sociable == null)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Sociable is null",
                    StatusCode = MyStatusCode.BadRequest,
                };
            }

            var result = await _userSociableRepository.Delete(sociable);

            if (result == false)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = "Error remove sociable",
                    StatusCode = MyStatusCode.InternalServerError,
                };
            }

            return new BaseResponse<bool>()
            {
                Data = true,
                Description = "Success",
                StatusCode = MyStatusCode.OK
            };
        }
    }
}
