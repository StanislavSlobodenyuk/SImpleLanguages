using Common.Response;
using Dal.Interfaces.LearnContent;
using Domain.Entity.Content.Lessons;
using Dto;
using Service.Interfaces.ILowLevelServices.LearnContentService;

namespace Service.Implementations.LowLevelServices.LearnContentServices
{
    public class CourseModuleService : ICourseModuleService
    {
        private readonly ICourseModuleRepository _courseModuleRepository;
        private readonly ICourseRepository _courseRepository;


        public CourseModuleService(ICourseModuleRepository courseModuleRepository, ICourseRepository courseRepository)
        {
            _courseModuleRepository = courseModuleRepository;
            _courseRepository = courseRepository;
        }
        public async Task<BaseResponse<IEnumerable<CourseModule>>> GetModules(int courseId)
        {
            if (courseId <= 0)
                return BaseResponseHelper.HandleBadRequest<IEnumerable<CourseModule>>($"Parameter is not correct, id <= 0");

            try
            {
                var course = await _courseRepository.GetById(courseId);
                if (course == null)
                {
                    return BaseResponseHelper.HandleNotFound<IEnumerable<CourseModule>>($"Id with course {courseId} not found");
                }

                var modules = await _courseModuleRepository.GetModules(courseId);

                return BaseResponseHelper.HandleSuccessfulRequest(modules);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<CourseModule>>("Failed get modules");
            }
        }
        public async Task<BaseResponse<CourseModule>> UpdateModule(UpdateCourseModuleDto updateDto, int courseId)
        {
            if (string.IsNullOrEmpty(updateDto.Title) && string.IsNullOrEmpty(updateDto.PathToMap))
                return BaseResponseHelper.HandleBadRequest<CourseModule>("Parameters are empty.");

            CourseModule? currentCourseModule = await _courseModuleRepository.GetById(courseId);

            if (currentCourseModule == null)
                return BaseResponseHelper.HandleNotFound<CourseModule>($"Course module with id {courseId} not found");

            try
            {
                var result = await _courseModuleRepository.Update(currentCourseModule);

                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<CourseModule>("Failed delete module");

                return BaseResponseHelper.HandleSuccessfulRequest(currentCourseModule);

            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<CourseModule>(" An unexpected error occurred.");
            }
        }
        public async Task<BaseResponse<CourseModule>> ChangeAvailableModule(int moduleId)
        {
            CourseModule? currentModule = await _courseModuleRepository.GetById(moduleId);
            if (currentModule == null)
                return BaseResponseHelper.HandleNotFound<CourseModule>($"Module with id {moduleId} not found");

            try
            {
                bool result = await _courseModuleRepository.ChangeAvailableModule(currentModule);

                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<CourseModule>("Error changing availability");

                return BaseResponseHelper.HandleSuccessfulRequest(currentModule);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<CourseModule>("An unexpected error occurred.");
            }
        }
    }
}
