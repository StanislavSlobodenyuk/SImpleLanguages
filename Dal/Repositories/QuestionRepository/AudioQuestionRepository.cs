
using Dal.Interfaces.QuestionRepository;
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.QuestionRepository
{
    public class AudioQuestionRepository : IAudioQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public AudioQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool?> CreateAudioQuestion(AudioQuestion audioQuestion)
        {
            if (string.IsNullOrEmpty(audioQuestion.AudioUrl) || string.IsNullOrEmpty(audioQuestion.RightAnswer) || string.IsNullOrEmpty(audioQuestion.Text))
                return false;
            try
            {
                var newQuestion = new AudioQuestion(audioQuestion.Text, audioQuestion.RightAnswer, audioQuestion.AudioUrl, audioQuestion.Type);

                await _context.AudioQuestions.AddAsync(newQuestion);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<AudioQuestion?> UpdateText(int audioQuestionId, string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;
            try
            {
                var question = await _context.AudioQuestions.FirstOrDefaultAsync(q => q.Id == audioQuestionId);

                if (question == null)
                    return null;

                question.UpdateText(text);

                _context.Entry(question).Property(q => q.Text).IsModified = true;
                await _context.SaveChangesAsync();

                return question;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<AudioQuestion?> UpdateAudioURL(int audioQuestionId, string audioUrl)
        {
            if (string.IsNullOrEmpty(audioUrl))
                return null;
            try
            {
                var question = await _context.AudioQuestions.FirstOrDefaultAsync(q => q.Id == audioQuestionId);

                if (question == null)
                    return null;

                question.UpdateAudioUrl(audioUrl);

                _context.Entry(question).Property(q => q.AudioUrl).IsModified = true;
                await _context.SaveChangesAsync();

                return question;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<AudioQuestion?> UpdateRightAnswer(int audioQuestionId, string rightAnswer)
        {
            if (string.IsNullOrEmpty(rightAnswer))
                return null;
            try
            {
                var question = await _context.AudioQuestions.FirstOrDefaultAsync(q => q.Id == audioQuestionId);

                if (question == null)
                    return null;

                question.UpdateRightAnswer(rightAnswer);

                _context.Entry(question).Property(q => q.RightAnswer).IsModified = true;
                await _context.SaveChangesAsync();

                return question;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
