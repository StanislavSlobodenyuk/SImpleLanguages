

using Common.Response;

namespace Service.Interfaces
{
    public interface IModuleLessons 
    {
        Task<BaseResponse<IModuleLessons>> GetLessons();
    }
}
