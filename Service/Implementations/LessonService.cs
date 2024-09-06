
using Common.Enum;
using Common.Response;
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Enum;
using Service.Interfaces;
using System.Reflection;

namespace Service.Implementations
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<BaseResponse<Lesson>> Create(string title, LanguageLevel difficult, bool isavailable, string iconpath)
        {
            if (string.IsNullOrEmpty(title) || !Enum.IsDefined(typeof(LanguageLevel), difficult))
                return BaseResponseHelper.HandleBadRequest<Lesson>("Invalid input parameters");

            try
            {
                var newLesson = new Lesson(title, difficult, isavailable, iconpath);

                var result = await _lessonRepository.Create(newLesson);

                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Failed to create instance");

                return new BaseResponse<Lesson>()
                {
                    Data = newLesson,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }
        public async Task<BaseResponse<bool>> Delete(int lessonId)
        {
            var existingLesson = await _lessonRepository.GetById(lessonId);

            if (existingLesson == null)
                return BaseResponseHelper.HandleNotFound<bool>($"Lesson with id {lessonId} not found");

            try
            {
                var result = await _lessonRepository.Delete(existingLesson);

                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<bool>("Failed to delete instance");

                return new BaseResponse<bool>()
                {
                    Data = result,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Server error");
            }
        }
        public async Task<BaseResponse<Lesson>> UpdateIcon(int lessonId, string iconpath)
        {
            var existingLesson = await _lessonRepository.GetById(lessonId);

            if (existingLesson == null)
                return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

            try
            {
                var newLesson = await _lessonRepository.UpdateIcon(existingLesson, iconpath);

                if (newLesson == null)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Failed update lesson icon");

                return new BaseResponse<Lesson>()
                {
                    Data = newLesson,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }
        public async Task<BaseResponse<Lesson>> UpdateTitle(int lessonId, string title)
        {
            var existingLesson = await _lessonRepository.GetById(lessonId);

            if (existingLesson == null)
                return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

            try
            {
                var newLesson = await _lessonRepository.UpdateTitle(existingLesson, title);

                if (newLesson == null)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Failed update lesson icon");

                return new BaseResponse<Lesson>()
                {
                    Data = newLesson,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }
        public async Task<BaseResponse<Lesson>> ChangeAvailable(int lessonId, bool isAvailabe)
        {
            var existingLesson = await _lessonRepository.GetById(lessonId);

            if (existingLesson == null)
                return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

            try
            {
                var newLesson = await _lessonRepository.ChangeAvailableLesson(existingLesson, isAvailabe);

                if (newLesson == null)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Failed update available");

                return new BaseResponse<Lesson>()
                {
                    Data = newLesson,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }

        public async Task<BaseResponse<Lesson>> GetLesson(int lessonId)
        {
            try
            {
                var currentLesson = await _lessonRepository.GetById(lessonId);

                if (currentLesson == null)
                    return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

                return new BaseResponse<Lesson>()
                {
                    Data = currentLesson,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }

        public async Task<BaseResponse<BaseQuestion>> AddQuestion(int lessonId, BaseQuestion question)
        {
            if (question == null)
                return BaseResponseHelper.HandleBadRequest<BaseQuestion>("Bad parameters in request");

            var currentModule = await _lessonRepository.GetById(lessonId);

            if (currentModule == null)
                return BaseResponseHelper.HandleNotFound<BaseQuestion>("The specified module was not found");

            try
            {
                var newQuestion = await _lessonRepository.AddQuestionToLesson(lessonId, question);

                if (newQuestion == null)
                    return BaseResponseHelper.HandleInternalServerError<BaseQuestion>("Error adding lesson");

                return new BaseResponse<BaseQuestion>
                {
                    Data = newQuestion,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<BaseQuestion>("Server error");
            }
        }
        public async Task<BaseResponse<bool>> DeleteQuestion(int lessonId, BaseQuestion question)
        {
            if (question == null)
                return BaseResponseHelper.HandleBadRequest<bool>("Bad parameters in request");

            var currentLessone = await _lessonRepository.GetById(lessonId);

            if (currentLessone == null)
                return BaseResponseHelper.HandleNotFound<bool>("The specified module was not found");

            try
            {
                bool result = await _lessonRepository.DeleteQuestionFromLesson(lessonId, question);
                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<bool>("Error deleting lesson");

                return new BaseResponse<bool>
                {
                    Data = true,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Error deleting lesson");
            }
        }
        public async Task<BaseResponse<bool>> DeleteAllQuestion(int lessonId, List<BaseQuestion> questions)
        {
            if (questions == null || questions.Any(l => l == null))
                return BaseResponseHelper.HandleBadRequest<bool>("Invalid questions list");

            var currentModule = await _lessonRepository.GetById(lessonId);

            if (currentModule == null)
                return BaseResponseHelper.HandleNotFound<bool>("Lesson not found");

            try
            {
                foreach (var question in questions)
                {
                    await _lessonRepository.DeleteQuestionFromLesson(lessonId, question);
                }

                return new BaseResponse<bool>
                {
                    Data = true,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Error deleting questions");
            }
        }

        public async Task<BaseResponse<IEnumerable<BaseQuestion>>> GetAllQuestionForThisLesson(int lessonId)
        {
            try
            {
                var currentLesson = await _lessonRepository.GetLessonWithQuestion(lessonId);

                if (currentLesson == null)
                    return BaseResponseHelper.HandleNotFound<IEnumerable<BaseQuestion>>("Lesson not found");

                var question = currentLesson.LessonQuestions
                    .Select(lq => lq.Question)
                    .OfType<BaseQuestion>()
                    .ToList();

                return new BaseResponse<IEnumerable<BaseQuestion>>()
                {
                    Data = question,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<BaseQuestion>>("Server error");
            }
        }
    }
}
