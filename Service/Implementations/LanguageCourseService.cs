
using Common.Enum;
using Common.Response;
using Common.Response.UpdateResponse;
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
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

        public async Task<BaseResponse<LanguageCourse>> CreateCourse(string languageName, string code, string iconPath)
        {
            var baseResponse = new BaseResponse<LanguageCourse>();

            if (string.IsNullOrEmpty(languageName) || string.IsNullOrEmpty(code) || string.IsNullOrEmpty(iconPath))
            {
                return new BaseResponse<LanguageCourse>()
                {
                    Description = "Unable to create course, error when entering parameters",
                    StatusCode = MyStatusCode.BadRequest
                };
            }

            try
            {
                var newCourse = new LanguageCourse(languageName, code, iconPath);

                bool result = await _courseRepository.Create(newCourse);

                if (result)
                {
                    baseResponse.Data = newCourse;
                    baseResponse.StatusCode = MyStatusCode.OK;

                    return baseResponse;
                }
                else
                {
                    return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Unable create new course");
                }
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Unable create new course");
            }
        }
        public async Task<BaseResponse<bool>> DeleteCourse(int courseID)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                var course = await _courseRepository.GetById(courseID);

                if (course != null) 
                {
                    baseResponse.Data =  await _courseRepository.Delete(course);
                    baseResponse.StatusCode = MyStatusCode.OK;
                    
                    return baseResponse;
                }
                else
                {
                    return BaseResponseHelper.HandleInternalServerError<bool>("Unable delete course");
                }
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Unable delete course");
            }
        }
        public async Task<BaseResponse<LanguageCourse>> Change(int courseId, UpdateCourseRequest updateCourseRequest)
        {
            var baseResponse = new BaseResponse<LanguageCourse>();

            if (updateCourseRequest == null)
            {
                return new BaseResponse<LanguageCourse>()
                {
                    Description = "Unable change course, error when entering parameters",
                    StatusCode = MyStatusCode.BadRequest,
                };
            }

            try
            {
                var existingCourse = await _courseRepository.GetById(courseId);

                if (existingCourse == null)
                {
                    baseResponse.StatusCode = MyStatusCode.NotFound;
                    baseResponse.Description = $"Course with ID {courseId} not found.";

                    return baseResponse;
                }

                existingCourse.Update(updateCourseRequest.LanguageName, updateCourseRequest.Code, updateCourseRequest.IconPath);

                var updatedCourse = await _courseRepository.Update(existingCourse);

                if (updatedCourse != null)
                {
                    baseResponse.Data = updatedCourse;
                    baseResponse.StatusCode = MyStatusCode.OK;
                }
                else
                {
                    return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Unable to update course.");
                }

                return baseResponse;
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Unable change course, database error");
            }
        }

        public async Task<BaseResponse<LanguageCourse>> GetCourseById(int id)
        {
            var baseResponse = new BaseResponse<LanguageCourse>();

            try
            {
                var course = await _courseRepository.GetById(id);

                if (course == null)
                {
                    baseResponse.StatusCode = MyStatusCode.NotFound;
                    baseResponse.Description = $"Course with ID {id} not found.";
                    return baseResponse;
                }

                baseResponse.Data = course;
                baseResponse.StatusCode =MyStatusCode.OK;

                return baseResponse;
            }
            catch (Exception)
            {

                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Course not Founde");
            }
        }
        public async Task<BaseResponse<LanguageCourse>> GetCourseByCode(string code)
        {
            var baseResponse = new BaseResponse<LanguageCourse>();

            if (string.IsNullOrEmpty(code))
            {
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Code empty or equal zero");
            }

            try
            {
                var course = await _courseRepository.GetCourseByCode(code);

                if (course == null)
                {
                    baseResponse.StatusCode = MyStatusCode.NotFound;
                    baseResponse.Description = $"Course with code {code} not found.";
                    return baseResponse;
                }

                baseResponse.Data = course;
                baseResponse.StatusCode = MyStatusCode.OK;

                return baseResponse;
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Course not Founde");
            }
        }
        public async Task<BaseResponse<LanguageCourse>> GetCourseByName(string languageName)
        {
           var baseResponse = new BaseResponse<LanguageCourse>();

            if (string.IsNullOrEmpty(languageName))
            {
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Language name empty or equal zero");
            }

            try
            {
                var course = await _courseRepository.GetCourseByLanguage(languageName);

                if (course == null)
                {
                    baseResponse.StatusCode = MyStatusCode.NotFound;
                    baseResponse.Description = $"Course {languageName} not found.";
                    return baseResponse;
                }

                baseResponse.Data = course;
                baseResponse.StatusCode = MyStatusCode.OK;

                return baseResponse;
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Course not Founde");
            }
        }

        public async Task<BaseResponse<ModuleLessons>> AddModule(int courseId, ModuleLessons moduleLessons)
        {
            var baseResponse = new BaseResponse<ModuleLessons>();

            try
            {
                var newCourse = await _courseRepository.AddModuleToCourse(courseId, moduleLessons);
                
                if (newCourse != null)
                {
                    baseResponse.Data = newCourse;
                    baseResponse.StatusCode = MyStatusCode.OK;

                    return baseResponse;
                }
                else
                {
                    return BaseResponseHelper.HandleInternalServerError<ModuleLessons>("Server error");
                }
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<ModuleLessons>("Server error");
            }
        }
        public async Task<BaseResponse<bool>> DeleteModule(int courseId, ModuleLessons moduleLessons)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                baseResponse.Data = await _courseRepository.DeleteModuleFromCourse(courseId, moduleLessons);
                baseResponse.StatusCode = MyStatusCode.OK;

                return baseResponse;
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Unable add new module to course");
            }
        }
        public async Task<BaseResponse<IEnumerable<ModuleLessons>>> GetAllModulesThisCourse(int courseId)
        {
            var baseResponse = new BaseResponse<IEnumerable<ModuleLessons>>();

            var existingCourse = await _courseRepository.GetById(courseId);

            if (existingCourse == null)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<ModuleLessons>>("Course not found");
            }

            try
            {
                baseResponse.Data = existingCourse.ModulesLessons;
                baseResponse.StatusCode = MyStatusCode.OK;

                return baseResponse;
            }
            catch (Exception)
            {

                return BaseResponseHelper.HandleInternalServerError<IEnumerable<ModuleLessons>>("Database error");
            }
        }

        public async Task<BaseResponse<IEnumerable<LanguageCourse>>> GetAllCourses()
        {
            var baseResponse = new BaseResponse<IEnumerable<LanguageCourse>>();

            try
            {
                baseResponse.Data = await _courseRepository.Select();
                baseResponse.StatusCode=MyStatusCode.OK;

                return baseResponse;
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<LanguageCourse>>("Unable to display all course items");
            }
        }
    }
}
