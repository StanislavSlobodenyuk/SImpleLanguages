
using Domain.Entity.Content.Question;

namespace Dal.Interfaces.QuestionRepository
{
    public interface IAudioQuestionRepository
    {
        Task<bool?> CreateAudioQuestion(AudioQuestion audioQuestion);

        Task<AudioQuestion?> UpdateAudioURL(int audioQuestionId, string audioUrl);
        Task<AudioQuestion?> UpdateRightAnswer(int audioQuestionId, string rightAnswer);
    }
}
