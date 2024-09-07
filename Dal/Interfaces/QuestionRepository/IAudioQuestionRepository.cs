
using Domain.Entity.Content.Question;

namespace Dal.Interfaces.QuestionRepository
{
    public interface IAudioQuestionRepository
    {
        Task<AudioQuestion?> CreateTestQuestion(AudioQuestion audioQuestion);

        Task<AudioQuestion?> UpdateText(int audioQuestionId, string text);
        Task<AudioQuestion?> UpdateAudioURL(int audioQuestionId, string audioUrl);
        Task<AudioQuestion?> UpdateRightAnswer(int audioQuestionId, string rightAnswer);
    }
}
