
using Common.Response;
using Domain.Entity.Content.Question;
using Domain.Enum;

namespace Service.Interfaces
{
    public interface IQuestionService
    {
        Task<BaseResponse<TestQuestion>> CreateTestQuestion(string text, TypeQuestion type, List<string> answerOptions, string answer);
        Task<BaseResponse<TestQuestion>?> UpdateTestQuestionText(int testQuestionId, string text);
        Task<BaseResponse<TestQuestion>?> UpdateAnswerOptions(int testQuestionId, List<string> answerOptions);
        Task<BaseResponse<TestQuestion>?> UpdateRightAnswer(int testQuestionId, string answer);

        Task<BaseResponse<AudioQuestion>> CreateAudioQuestion(string text, string rightAnswer, string audioUrl, TypeQuestion type);
        Task<BaseResponse<AudioQuestion>> UpdateAudioQuestionAudioUrl(int audioQuestionId, string newText);
        Task<BaseResponse<AudioQuestion>> UpdateAudioQuestionRightAnswer(int audioQuestionId, string newText);

        Task<BaseResponse<bool>> DeleteQuestion(int questionId, TypeQuestion type);
        Task<BaseResponse<BaseQuestion>?> GetQuestion(int questionId, TypeQuestion type);
        //Task<BaseResponse<string>?> GetRigthAnswer(int questionId, QuestionType type);
    }
}
