
using Common.Response;
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Service.Interfaces;

namespace Service.Implementations
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ICourseModuleRepository _courseModuleRepository;

        public LessonService(ILessonRepository lessonRepository, ICourseModuleRepository courseModuleRepository)
        {
            _lessonRepository = lessonRepository;
            _courseModuleRepository = courseModuleRepository;
        }

        public async Task<BaseResponse<IEnumerable<Lesson>>> GetLessons(int moduleId)
        {
            if (moduleId <= 0)
                return BaseResponseHelper.HandleBadRequest<IEnumerable<Lesson>>($"Invalid parameter moduleId <= 0");
            
            try
            {
                var courseModule = await _courseModuleRepository.GetById(moduleId);

                if (courseModule == null)
                {
                    return BaseResponseHelper.HandleNotFound<IEnumerable<Lesson>>($"Module with {moduleId} not found");
                }
                
                var lesssons = await _lessonRepository.GetLessons(moduleId);

                return BaseResponseHelper.HandleSuccessfulRequest(lesssons);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<Lesson>>("Server internal error");
            }
        }
        public async Task<BaseResponse<Lesson>> ChangeAvailable(int lessonId)
        {
            Lesson? currentLesson = await _lessonRepository.GetById(lessonId);

            if (currentLesson == null)
                return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

            try
            {
                var newLesson = await _lessonRepository.ChangeAvailableLesson(currentLesson);

                if (newLesson == null)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Failed update available");

                return BaseResponseHelper.HandleSuccessfulRequest(newLesson); ;
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }

    }
}
