

using Common.Response;
using Domain.Entity.Content.Lessons;
using Dto;

namespace Service.Interfaces
{
    public interface ICourseModuleService 
    {
        Task<BaseResponse<CourseModule>> UpdateModule(UpdateCourseModuleDto updateDto ,int moduleId);
        Task<BaseResponse<CourseModule>> GetModule(int moduleId);
        Task<BaseResponse<CourseModule>> ChangeAvailableModule(int moduleId);

        Task<BaseResponse<CourseModule>> AddLesson(Lesson lesson, int moduleId);
        Task<BaseResponse<bool>> DeleteLesson(int moduleId, int lessonId);
    }
}
