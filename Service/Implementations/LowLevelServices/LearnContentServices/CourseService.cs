using Common.Response;
using Domain.Entity.Content.CourseContent;
using Domain.Enum;
using Dto;
using Dal.Interfaces.LearnContent;
using Service.Interfaces.ILowLevelServices.LearnContentService;

namespace Service.Implementations.LowLevelServices.LearnContentServices
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<BaseResponse<IEnumerable<Course>>> GetFillterCourses(CourseFilterDto courseFilter)
        {
            int[] lessonCount = [0];
            if (courseFilter.LessonCount != null && courseFilter.LessonCount.ToLower() != "all")
            {
                string[] values = courseFilter.LessonCount.Split('-');
                lessonCount = values.Select(int.Parse).ToArray();
            }

            var languageEnum = LanguageName.All;
            if (courseFilter.Language != null)
            {
                languageEnum = Enum.TryParse<LanguageName>(courseFilter.Language, true, out var parsedLanguage) ? parsedLanguage : LanguageName.All;
            }

            var levelEnum = LanguageLevel.All;
            if (courseFilter.Level != null)
            {
                levelEnum = Enum.TryParse<LanguageLevel>(courseFilter.Level, true, out var parsedLevel) ? parsedLevel : LanguageLevel.All;
            }
            try
            {
                IEnumerable<Course> filterCourses = await _courseRepository.GetFillterCourses(
                    courseFilter.SearchTitle,
                    languageEnum,
                    levelEnum,
                    lessonCount,
                    courseFilter.Cost,
                    courseFilter.InDevelopment
                );

                return BaseResponseHelper.HandleSuccessfulRequest(filterCourses);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<Course>>("Unable to display all course items");
            }
        }
        public async Task<BaseResponse<Course>> GetCourse(int courseId)
        {
            if (courseId <= 0)
                return BaseResponseHelper.HandleBadRequest<Course>($"Invalid parameters {courseId} <= 0");

            try
            {
                var course = await _courseRepository.GetById(courseId);

                if (course == null)
                    return BaseResponseHelper.HandleNotFound<Course>($"Course with id {courseId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(course);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Course>("Course not found");
            }
        }
        public async Task<BaseResponse<Course>> CreateCourse(Course course)
        {
            if (string.IsNullOrEmpty(course.Title)
                || string.IsNullOrEmpty(course.ImgPath)
                || string.IsNullOrEmpty(course.Description)
                || !Enum.IsDefined(typeof(LanguageLevel), course.Language)
                || !Enum.IsDefined(typeof(LanguageLevel), course.Level))
                return BaseResponseHelper.HandleInternalServerError<Course>("Invalid parameters");

            try
            {
                var newCourse = new Course(course.Title, course.Description, course.Language, course.Level, course.ImgPath);

                bool result = await _courseRepository.Create(newCourse);

                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<Course>("Not found create course");

                return BaseResponseHelper.HandleSuccessfulRequest(newCourse);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Course>("Unable create new course");
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
        public async Task<BaseResponse<Course>> UpdateCourse(UpdateCourseDto course, int courseId)
        {
            if (course == null)
                return BaseResponseHelper.HandleBadRequest<Course>("Parameters is bad");

            Course? currentCourse = await _courseRepository.GetById(courseId);

            if (currentCourse == null)
                return BaseResponseHelper.HandleNotFound<Course>($"Course with id {courseId} not found");

            try
            {
                currentCourse.Title = course.Name;
                currentCourse.Description = course.Description;
                currentCourse.ImgPath = course.IconPath;

                bool result = await _courseRepository.Update(currentCourse);
                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<Course>("Failed update course");

                return BaseResponseHelper.HandleSuccessfulRequest(currentCourse);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
