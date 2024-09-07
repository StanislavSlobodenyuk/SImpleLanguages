
using Common.Enum;
using Common.Response;
using Dal.Interfaces;
using Dal.Interfaces.QuestionRepository;
using Domain.Entity.Content.Question;
using Domain.Enum;
using Service.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Service.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IBaseQuestionRepository _baseQuestionRepository;
        private readonly ITestQuestionRepository _testQuestionRepository;
        private readonly IAudioQuestionRepository _audioQuestionRepository; 

        public QuestionService(IBaseQuestionRepository baseQuestionRepository, 
            ITestQuestionRepository testQuestionRepository, 
            IAudioQuestionRepository audioQuestionRepository)
        {
            _baseQuestionRepository = baseQuestionRepository;
            _testQuestionRepository = testQuestionRepository;
            _audioQuestionRepository = audioQuestionRepository;
        }


        public async Task<BaseResponse<AudioQuestion>> CreateAudioQuestion(string text, string rightAnswer, string audioUrl, QuestionType type)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(rightAnswer) || string.IsNullOrEmpty(audioUrl))
                return BaseResponseHelper.HandleBadRequest<AudioQuestion>("Invalid parameters");

            try
            {
                var newQuestion = new AudioQuestion(text, rightAnswer, audioUrl, type);
                var result = await _audioQuestionRepository.CreateAudioQuestion(newQuestion);

                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<AudioQuestion>("Failed create new question");

                return BaseResponseHelper.HandleSuccessfulRequest(newQuestion);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<AudioQuestion>("Failed create new question");
            }
        }
        public async Task<BaseResponse<AudioQuestion>> UpdateAudioQuestionAudioUrl(int audioQuestionId, string newAudioUrl)
        {
            try
            {
                var updateQuestion = await _audioQuestionRepository.UpdateAudioURL(audioQuestionId, newAudioUrl);

                if (updateQuestion == null)
                    return BaseResponseHelper.HandleNotFound<AudioQuestion>($"Audio question with id {audioQuestionId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(updateQuestion);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<AudioQuestion>($"Failed to update audio url question with id {audioQuestionId}");
            }
        }
        public async Task<BaseResponse<AudioQuestion>> UpdateAudioQuestionRightAnswer(int audioQuestionId, string rightAnswer)
        {
            try
            {
                var updateQuestion = await _audioQuestionRepository.UpdateRightAnswer(audioQuestionId, rightAnswer);

                if (updateQuestion == null)
                    return BaseResponseHelper.HandleNotFound<AudioQuestion>($"Audio question with id {audioQuestionId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(updateQuestion);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<AudioQuestion>($"Failed to update right answer for question with id {audioQuestionId}");
            }
        }
        public async Task<BaseResponse<AudioQuestion>> UpdateAudioQuestionText(int audioQuestionId, string newText)
        {
            try
            {
                var updateQuestion = await _audioQuestionRepository.UpdateText(audioQuestionId, newText);

                if (updateQuestion == null)
                    return BaseResponseHelper.HandleNotFound<AudioQuestion>($"Audio question with id {audioQuestionId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(updateQuestion);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<AudioQuestion>($"Failed to update text for question with id {audioQuestionId}");
            }
        }

        public async Task<BaseResponse<TestQuestion>> CreateTestQuestion(string text, QuestionType type, List<string> answerOptions, string answer)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(answer) || answerOptions.Any(l => l == null))
                return BaseResponseHelper.HandleBadRequest<TestQuestion>("Invalid parameters");

            try
            {
                var newQuestion = new TestQuestion(text, type);

                var newAnswerOptions = answerOptions
                     .Select(optionText => new TestAnswerOption(optionText))
                     .ToList();

                var newRightAnswer = new TestRightAnswer(answer);

                var result = await _testQuestionRepository.CreateTestQuestion(newQuestion, newAnswerOptions, newRightAnswer);

                if (result == false)
                    return BaseResponseHelper.HandleInternalServerError<TestQuestion>("Failed create new test question");

                return BaseResponseHelper.HandleSuccessfulRequest(newQuestion);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<TestQuestion>("Failed create new text question");
            }
        }
        public async Task<BaseResponse<TestQuestion>?> UpdateAnswerOptions(int testQuestionId, List<string> answerOptions)
        {
            try
            {
                var newAnswerOptions = answerOptions
                     .Select(optionText => new TestAnswerOption(optionText))
                     .ToList();

                var updateQuestion = await _testQuestionRepository.UpdateAnswerOptions(testQuestionId, newAnswerOptions);

                if (updateQuestion == null)
                    return BaseResponseHelper.HandleNotFound<TestQuestion>($"Test question with id {testQuestionId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(updateQuestion);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<TestQuestion>($"Failed to update answer options for question with id {testQuestionId}");
            };
        }
        public async Task<BaseResponse<TestQuestion>?> UpdateRightAnswer(int testQuestionId, string answer)
        {
            try
            {
                var newRightAnswer = new TestRightAnswer(answer);

                var updateQuestion = await _testQuestionRepository.UpdateRightAnswer(testQuestionId, newRightAnswer);

                if (updateQuestion == null)
                    return BaseResponseHelper.HandleNotFound<TestQuestion>($"Test question with id {testQuestionId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(updateQuestion);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<TestQuestion>($"Failed to update answer for question with id {testQuestionId}");
            };
        }
        public async Task<BaseResponse<TestQuestion>?> UpdateTestQuestionText(int testQuestionId, string text)
        {
            try
            {

                var updateQuestion = await _testQuestionRepository.UpdateQuestionText(testQuestionId, text);

                if (updateQuestion == null)
                    return BaseResponseHelper.HandleNotFound<TestQuestion>($"Test question with id {testQuestionId} not found");

                return BaseResponseHelper.HandleSuccessfulRequest(updateQuestion);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<TestQuestion>($"Failed to update text for question with id {testQuestionId}");
            };
        }

        public async Task<BaseResponse<bool>> DeleteQuestion(int questionId, QuestionType type)
        {
            try
            {
                var result = await _baseQuestionRepository.DeleteQuestion(questionId, type);

                if (result == false)
                    return BaseResponseHelper.HandleNotFound<bool>("Question not found");

                return BaseResponseHelper.HandleSuccessfulRequest(result);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>($"Failed to delete question");
            }
        }
        public async Task<BaseResponse<BaseQuestion>?> GetQuestion(int questionId, QuestionType type)
        {
            try
            {
                var result = await _baseQuestionRepository.GetQuestion(questionId, type);

                if (result == null)
                    return BaseResponseHelper.HandleNotFound<BaseQuestion>("Question not found");

                return BaseResponseHelper.HandleSuccessfulRequest(result);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<BaseQuestion>($"Failed to found question");
            }
        }
        public async Task<BaseResponse<string>?> GetRigthAnswer(int questionId, QuestionType type)
        {
            try
            {
                var result = await _baseQuestionRepository.GetRigthAnswer(questionId, type);

                if (string.IsNullOrEmpty(result))
                    return BaseResponseHelper.HandleNotFound<string>("Question not found");

                return BaseResponseHelper.HandleSuccessfulRequest(result);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<string>($"Failed to found question");
            }
        }
    }
}
