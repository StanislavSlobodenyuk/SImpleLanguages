
using Common.Enum;

namespace Common.Response
{
    public static class BaseResponseHelper
    {
        public static BaseResponse<T> HandleInternalServerError<T>(string description)
        {
            return new BaseResponse<T>()
            {
                StatusCode = MyStatusCode.InternalServerError,
                Description = description,
            };
        }

        public static BaseResponse<T> HandleNotFound<T>(string description)
        {
            return new BaseResponse<T>()
            {
                StatusCode = MyStatusCode.NotFound,
                Description = description
            };
        }

        public static BaseResponse<T> HandleBadRequest<T>(string description)
        {
            return new BaseResponse<T>()
            {
                StatusCode = MyStatusCode.BadRequest,
                Description = description
            };
        }
        public static BaseResponse<T> HandleSuccessfulRequest<T>(T data)
        {
            return new BaseResponse<T>()
            {
                Data = data,
                StatusCode = MyStatusCode.OK,
            };
        }
    }
}
