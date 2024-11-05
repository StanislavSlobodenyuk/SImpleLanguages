
using Common.Response;
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Service.Interfaces;

namespace Service.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILessonRepository _lessonRepository;

        public QuestionService(IQuestionRepository questionRepository, ILessonRepository lessonRepository)
        {
            _questionRepository = questionRepository;
            _lessonRepository = lessonRepository;
        }

        public async Task<BaseResponse<IEnumerable<BaseQuestion>>> GetQuestions(int lessonId)
        {
            if (lessonId <= 0)
                return BaseResponseHelper.HandleBadRequest<IEnumerable<BaseQuestion>>("Invalid parameter lessonId <= 0");

            try
            {
                var lesson = await _lessonRepository.GetById(lessonId);

                if (lesson == null)
                    return BaseResponseHelper.HandleNotFound<IEnumerable<BaseQuestion>>($"Lesson with id {lessonId} not found");

                var question = await _questionRepository.GetQuestions(lessonId);

                return BaseResponseHelper.HandleSuccessfulRequest(question);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<BaseQuestion>>("Server internal error");
            }
        }
    }
}
