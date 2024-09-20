using Common.Enum;
using Common.Response;
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;
using Dto;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Implementations
{
    public  class LanguageCourseService : ILanguageCourseService
    {
        private readonly ILanguageCourseRepository _courseRepository;

        public LanguageCourseService(ILanguageCourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<BaseResponse<LanguageCourse>> CreateCourse(LanguageCourse course)
        {
            if (string.IsNullOrEmpty(course.Name) || string.IsNullOrEmpty(course.IconPath) || 
                !Enum.IsDefined(typeof(LanguageLevel), course.Language) || 
                !Enum.IsDefined(typeof(LanguageLevel), course.Difficult))
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Invalid parameters");

            try
            {
                var newCourse = new LanguageCourse(course.Name, course.Description, course.Language, course.Difficult, course.IconPath);

                bool result = await _courseRepository.Create(newCourse);

                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Not found create course");

                return BaseResponseHelper.HandleSuccessfulRequest(newCourse);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Unable create new course");
            }
        }
        public async Task<BaseResponse<bool>> DeleteCourse(int courseID)
        {
            try
            {
                var course = await _courseRepository.GetById(courseID);

                if (course == null)
                    return BaseResponseHelper.HandleNotFound<bool>("Course not found"); ;
                
                var result = await _courseRepository.Delete(course);

                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<bool>("Unable delete course");

                return BaseResponseHelper.HandleSuccessfulRequest(result);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Unable delete course");
            }
        }
        public async Task<BaseResponse<LanguageCourse>> UpdateCourse(UpdateCourseDto course, int courseId) 
        {
            if (course == null)
                return BaseResponseHelper.HandleBadRequest<LanguageCourse>("Parameters is bad");

            LanguageCourse? currentCourse = await _courseRepository.GetById(courseId);

            if (currentCourse == null)
                return BaseResponseHelper.HandleNotFound<LanguageCourse>($"Course with id {courseId} not found");

            try
            {
                currentCourse.Name = course.Name;
                currentCourse.Description = course.Description;
                currentCourse.IconPath = course.IconPath;

                bool result = await _courseRepository.Update(currentCourse);
                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Failed update course");

                return BaseResponseHelper.HandleSuccessfulRequest(currentCourse);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BaseResponse<LanguageCourse>> GetCourseById(int courseId)
        {
            try
            {
                var course = await _courseRepository.GetById(courseId);

                if (course == null)
                    return BaseResponseHelper.HandleNotFound<LanguageCourse>($"Course with id {courseId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(course);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Course not Founde");
            }
        }

        public async Task<BaseResponse<CourseModule>> AddModule(CourseModule moduleLessons, int courseId)
        {
            if (moduleLessons == null)
                return BaseResponseHelper.HandleBadRequest<CourseModule>("Parameter is bad");

            try
            {
                var currentCourse = await _courseRepository.GetById(courseId);

                if (currentCourse == null)
                    return BaseResponseHelper.HandleInternalServerError<CourseModule>($"Course with id {courseId} not found");

                CourseModule? newModule = await _courseRepository.AddModuleToCourse(courseId, moduleLessons);

                if (newModule == null)
                    return BaseResponseHelper.HandleInternalServerError<CourseModule>("An unexpected error occurred.");

                return BaseResponseHelper.HandleSuccessfulRequest(newModule);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<CourseModule>("An unexpected error occurred.");
            }
        }
        public async Task<BaseResponse<bool>> DeleteModule(int courseId, int moduleId)
        {
            LanguageCourse? currentCourse = await _courseRepository.GetById(courseId);

            if (currentCourse == null)
                return BaseResponseHelper.HandleNotFound<bool>($"Course with id {courseId} not found");
            

            try
            {
                var result = await _courseRepository.DeleteModuleFromCourse(courseId, moduleId);

                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<bool>("Failed delete module from course");

                return BaseResponseHelper.HandleSuccessfulRequest(result);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Unable add new module to course");
            }
        }

        public async Task<BaseResponse<IEnumerable<LanguageCourse>>> GetFillterCourses(CourseFilterDto courseFilter)
        {
            if (string.IsNullOrEmpty(courseFilter.SearchName)
                && Enum.IsDefined(typeof(LanguageName), courseFilter.Language)
                && Enum.IsDefined(typeof(LanguageLevel), courseFilter.Difficult))
                return BaseResponseHelper.HandleBadRequest<IEnumerable<LanguageCourse>>("Bad parameters");
            try
            {
                IEnumerable<LanguageCourse> filterCourses = await _courseRepository.GetCourses();

                if (filterCourses == null || !filterCourses.Any())
                    return BaseResponseHelper.HandleNotFound<IEnumerable<LanguageCourse>>("Courses by fillter not found");

                return BaseResponseHelper.HandleSuccessfulRequest(filterCourses);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<LanguageCourse>>("Unable to display all course items");
            }
        }
    }
}
