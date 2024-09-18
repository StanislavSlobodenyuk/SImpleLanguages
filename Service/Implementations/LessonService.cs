
using Common.Enum;
using Common.Response;
using Dal.Interfaces.LessonRepository;
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

        public async Task<BaseResponse<Lesson>> Create(string title, bool isavailable, string iconpath)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(title))
                return BaseResponseHelper.HandleBadRequest<Lesson>("Invalid input parameters");

            try
            {
                var newLesson = new Lesson(title, isavailable, iconpath);

                var result = await _lessonRepository.Create(newLesson);

                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Failed to create instance");

                return BaseResponseHelper.HandleSuccessfulRequest(newLesson);
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

                return BaseResponseHelper.HandleSuccessfulRequest(result);
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

                return BaseResponseHelper.HandleSuccessfulRequest(newLesson);
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

                return BaseResponseHelper.HandleSuccessfulRequest(newLesson);
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

                return BaseResponseHelper.HandleSuccessfulRequest(newLesson); ;
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

                return BaseResponseHelper.HandleSuccessfulRequest(currentLesson);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }

        public async Task<BaseResponse<Lesson>> AddQuestion(int lessonId, BaseQuestion question)
        {
            if (question == null)
                return BaseResponseHelper.HandleBadRequest<Lesson>("Bad parameters in request");

            var currentLesson = await _lessonRepository.GetById(lessonId);

            if (currentLesson == null)
                return BaseResponseHelper.HandleNotFound<Lesson>("The specified lesson was not found");

            try
            {
                var newQuestion = await _lessonRepository.AddQuestionToLesson(lessonId, question);

                if (newQuestion == null)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Error adding lesson");

                Lesson? updateLesson = await _lessonRepository.GetById(lessonId);

                if (updateLesson == null)
                    return BaseResponseHelper.HandleNotFound<Lesson>("The specified lesson was not found");

                return BaseResponseHelper.HandleSuccessfulRequest(updateLesson);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }
        public async Task<BaseResponse<Lesson>> DeleteQuestion(int lessonId, BaseQuestion question)
        {
            if (question == null)
                return BaseResponseHelper.HandleBadRequest<Lesson>("Bad parameters in request");

            var currentLessone = await _lessonRepository.GetById(lessonId);

            if (currentLessone == null)
                return BaseResponseHelper.HandleNotFound<Lesson>("The specified module was not found");

            try
            {
                var result = await _lessonRepository.DeleteQuestionFromLesson(lessonId, question);
                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Error deleting lesson");

                Lesson? updateLesson = await _lessonRepository.GetById(lessonId);

                if (updateLesson == null)
                    return BaseResponseHelper.HandleNotFound<Lesson>("The specified lesson was not found");

                return BaseResponseHelper.HandleSuccessfulRequest(updateLesson);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Error deleting lesson");
            }
        }
        public async Task<BaseResponse<Lesson>> DeleteAllQuestion(int lessonId, List<BaseQuestion> questions)
        {
            if (questions == null || questions.Any(l => l == null))
                return BaseResponseHelper.HandleBadRequest<Lesson>("Invalid questions list");

            var currentModule = await _lessonRepository.GetById(lessonId);

            if (currentModule == null)
                return BaseResponseHelper.HandleNotFound<Lesson>("Lesson not found");

            try
            {
                List<bool?> results = new List<bool?>();
                foreach (var question in questions)
                {
                    results.Add(await _lessonRepository.DeleteQuestionFromLesson(lessonId, question));
                }

                foreach(var res in results)
                {
                    if (res == false)
                        return BaseResponseHelper.HandleNotFound<Lesson>("Error deleting questions");
                }

                Lesson? updateLesson = await _lessonRepository.GetById(lessonId);

                if (updateLesson == null)
                    return BaseResponseHelper.HandleNotFound<Lesson>("Error deleting questions");

                return BaseResponseHelper.HandleSuccessfulRequest(updateLesson);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Error deleting questions");
            }
        }

        public async Task<BaseResponse<IEnumerable<BaseQuestion>>> GetAllQuestionForThisLesson(int lessonId)
        {
            try
            {
                var currentLesson = await _lessonRepository.GetById(lessonId);

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

        public async Task<BaseResponse<Lesson>> AddLecture(LectureBlock lecture, int lessonId)
        {
            if (lecture == null)
                return BaseResponseHelper.HandleNotFound<Lesson>("Lecture not found");

            try
            {
                Lesson? currentLesson = await _lessonRepository.GetById(lessonId);

                if (currentLesson == null)
                    return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

                Lesson? updateLesson = await _lessonRepository.AddLecture(lessonId, lecture);
                
                if (updateLesson == null)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Error adding lecture to lesson");

                return BaseResponseHelper.HandleSuccessfulRequest<Lesson>(updateLesson);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<BaseResponse<Lesson>> DeleteLecture(LectureBlock lecture, int lessonId)
        {
            if (lecture == null)
                return BaseResponseHelper.HandleNotFound<Lesson>("Lecture not found");

            try
            {
                Lesson? currentLesson = await _lessonRepository.GetById(lessonId);

                if (currentLesson == null)
                    return BaseResponseHelper.HandleNotFound<Lesson>($"Lesson with id {lessonId} not found");

                var result = await _lessonRepository.DeleteLecture(lessonId, lecture);

                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Error delete lecture from lesson");

                Lesson? updateLesson = await _lessonRepository.GetById(lessonId);

                if (updateLesson == null)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Lesson not found");

                return BaseResponseHelper.HandleSuccessfulRequest<Lesson>(updateLesson);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
