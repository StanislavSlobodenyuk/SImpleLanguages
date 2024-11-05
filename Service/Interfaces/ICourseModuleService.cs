using Common.Response;
using Domain.Entity.Content.Lessons;
using Dto;


namespace Service.Interfaces
{
    public interface ICourseModuleService 
    {
        Task<BaseResponse<IEnumerable<CourseModule>>> GetModules(int courseId);
        Task<BaseResponse<CourseModule>> UpdateModule(UpdateCourseModuleDto updateDto ,int moduleId);
        Task<BaseResponse<CourseModule>> ChangeAvailableModule(int moduleId);
    }
}
