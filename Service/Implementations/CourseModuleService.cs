
using Common.Enum;
using Common.Response;
using Dal.Interfaces.LessonRepository;
using Domain.Entity.Content.Lessons;
using Dto;
using Service.Interfaces;
using System.Reflection;

namespace Service.Implementations
{
    public class CourseModuleService : ICourseModuleService
    {
        private readonly ICourseModuleRepository _moduleLessonsRepository;

        public CourseModuleService( ICourseModuleRepository moduleLessonsRepository)
        { 
            _moduleLessonsRepository = moduleLessonsRepository;
        }

        public async Task<BaseResponse<CourseModule>> UpdateModule(CourseModuleUpdateDto updateDto, int courseId)
        {
            if (string.IsNullOrEmpty(updateDto.Title) && string.IsNullOrEmpty(updateDto.PathToMap))
                return BaseResponseHelper.HandleBadRequest<CourseModule>("Parameters are empty.");

            CourseModule? currentCourseModule = await _moduleLessonsRepository.GetById(courseId);

            if (currentCourseModule == null)
                return BaseResponseHelper.HandleNotFound<CourseModule>($"Course module with id {courseId} not found");

            try
            {
                var result = await _moduleLessonsRepository.Update(currentCourseModule);

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
            CourseModule? currentModule = await _moduleLessonsRepository.GetById(moduleId);
            if (currentModule == null)
                return BaseResponseHelper.HandleNotFound<CourseModule>($"Module with id {moduleId} not found");

            try
            {
                bool result = await _moduleLessonsRepository.ChangeAvailableModule(currentModule);

                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<CourseModule>("Error changing availability");

                return BaseResponseHelper.HandleSuccessfulRequest(currentModule);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<CourseModule>("An unexpected error occurred.");
            }
        }
        
        public async Task<BaseResponse<CourseModule>> GetModule(int moduleId)
        {
            try
            {
                var module = await _moduleLessonsRepository.GetById(moduleId);

                if (module == null)
                    return BaseResponseHelper.HandleNotFound<CourseModule>("Module not found");

                return BaseResponseHelper.HandleSuccessfulRequest(module);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<CourseModule>("Error fetching module");
            }
        }
       
        public async Task<BaseResponse<CourseModule>> AddLesson(Lesson lesson, int moduleId)
        {
            if (lesson == null)
                return BaseResponseHelper.HandleBadRequest<CourseModule>("Bad parameters in request");

            var currentModule = await _moduleLessonsRepository.GetById(moduleId);

            if (currentModule == null)
                return BaseResponseHelper.HandleNotFound<CourseModule>($"Module with id {moduleId} was not found");

            try
            {
                var newLesson = await _moduleLessonsRepository.AddLessonToModule(lesson, moduleId);

                if (newLesson == null)
                    return BaseResponseHelper.HandleInternalServerError<CourseModule>("Error adding lesson");

                return BaseResponseHelper.HandleSuccessfulRequest(currentModule);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<CourseModule>("Server error");
            }
        }
        public async Task<BaseResponse<bool>> DeleteLesson(int moduleId, int lessonId)
        {
            CourseModule? currentModule = await _moduleLessonsRepository.GetById(moduleId);

            if (currentModule == null)
                return BaseResponseHelper.HandleNotFound<bool>($"The module with id {moduleId} was not found");

            Lesson? currentLesson =  currentModule.Lessons.FirstOrDefault(l => l.Id == moduleId);

            if (currentLesson == null)
                return BaseResponseHelper.HandleNotFound<bool>($"The lesson with id {lessonId} was not found");

            try
            {
                bool result = await _moduleLessonsRepository.DeleteLessonFromModule(currentModule, currentLesson);
                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<bool>("Error deleting lesson from module");

                return BaseResponseHelper.HandleSuccessfulRequest(true);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Error deleting lesson");
            }
        }
    }
}
