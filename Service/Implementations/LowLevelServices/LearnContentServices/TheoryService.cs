using Common.Response;
using Dal.Interfaces.LearnContent;
using Domain.Entity.Content.Lessons;
using Service.Interfaces.ILowLevelServices.LearnContentService;

namespace Service.Implementations.LowLevelServices.LearnContentServices
{
    public class TheoryService : ITheoryService
    {
        private readonly ITheoryRepository _theoryRepository;
        private readonly ILessonRepository _lessonRepository;

        public TheoryService(ITheoryRepository theoryRepository, ILessonRepository lessonRepository)
        {
            _theoryRepository = theoryRepository;
            _lessonRepository = lessonRepository;
        }

        public async Task<BaseResponse<IEnumerable<Theory>>> GetTheories(int lessonId)
        {
            if (lessonId <= 0)
                return BaseResponseHelper.HandleBadRequest<IEnumerable<Theory>>("Invalid parameter lessonId <= 0");

            try
            {
                var lesson = await _lessonRepository.GetById(lessonId);

                if (lesson == null)
                    return BaseResponseHelper.HandleNotFound<IEnumerable<Theory>>($"Lesson with id {lessonId} not found");

                var theories = await _theoryRepository.GetTheories(lessonId);

                return BaseResponseHelper.HandleSuccessfulRequest(theories);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<Theory>>("Server internal error");
            }
        }
    }
}
