using Common.Enum;
using Common.Response;
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;
using Service.Interfaces;

namespace Service.Implementations
{
    public  class LanguageCourseService : ILanguageCourseService
    {
        private readonly ILanguageCourseRepository _courseRepository;

        public LanguageCourseService(ILanguageCourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<BaseResponse<LanguageCourse>> CreateCourse(string name, string description, LanguageName languageName, LanguageLevel difficult, string iconPath)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(iconPath) || 
                !Enum.IsDefined(typeof(LanguageLevel), languageName) || 
                !Enum.IsDefined(typeof(LanguageLevel), difficult))
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Invalid parameters");

            try
            {
                var newCourse = new LanguageCourse(name, description, languageName, difficult , iconPath);

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
        public async Task<BaseResponse<LanguageCourse>> GetCourseByName(LanguageName languageName)
        {
            try
            {
                var course = await _courseRepository.GetCourseByLanguage(languageName);

                if (course == null)
                    return BaseResponseHelper.HandleNotFound<LanguageCourse>($"Course with language {languageName} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(course);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<LanguageCourse>("Course not Founde");
            }
        }

        public async Task<BaseResponse<ModuleLessons>> AddModule(int courseId, ModuleLessons moduleLessons)
        {
            try
            {
                var newCourse = await _courseRepository.AddModuleToCourse(courseId, moduleLessons);

                if (newCourse == null)
                    return BaseResponseHelper.HandleInternalServerError<ModuleLessons>($"Failed add module to course");

                return BaseResponseHelper.HandleSuccessfulRequest(newCourse);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<ModuleLessons>("Server error");
            }
        }
        public async Task<BaseResponse<bool>> DeleteModule(int courseId, ModuleLessons moduleLessons)
        {
            try
            {
                var result =  await _courseRepository.DeleteModuleFromCourse(courseId, moduleLessons);

                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<bool>("Failed delete module from course");

                return BaseResponseHelper.HandleSuccessfulRequest(result);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Unable add new module to course");
            }
        }

        public async Task<BaseResponse<IEnumerable<ModuleLessons>>> GetAllModulesThisCourse(int courseId)
        {

            var existingCourse = await _courseRepository.GetById(courseId);

            if (existingCourse == null)
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<ModuleLessons>>("Course not found");

            try
            {
                return new BaseResponse<IEnumerable<ModuleLessons>>
                {
                    Data = existingCourse.ModulesLessons,
                    StatusCode = MyStatusCode.OK
                };
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
