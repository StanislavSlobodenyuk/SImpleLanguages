using Common.Enum;

namespace Common.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; } = "Error";
        public MyStatusCode StatusCode { get; set; }
        public T? Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T? Data { get; set; }
    }
}

