
using Common.Response;
using Dal.Interfaces.LessonRepositories;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Service.Interfaces;

namespace Service.Implementations
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<BaseResponse<Lesson>> GetLesson(int lessonId)
        {
            Lesson? currentLesson = await _lessonRepository.GetById(lessonId);
            
            try
            {
                if (currentLesson == null)
                    return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(currentLesson);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }
        public async Task<BaseResponse<Lesson>> GetLessonLecture(int lessonId)
        {
            Lesson? currentLesson = await _lessonRepository.GetLecture(lessonId);

            try
            {
                if (currentLesson == null)
                    return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(currentLesson);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }
        public async Task<BaseResponse<Lesson>> GetLessonPractice(int lessonId)
        {
            Lesson? currentLesson = await _lessonRepository.GetPractice(lessonId);

            try
            {
                if (currentLesson == null)
                    return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(currentLesson);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
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
