
using Dal.Interfaces.QuestionRepository;
using Domain.Entity.Content.Question;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.QuestionRepository
{
    public class BaseQuestionRepository : IBaseQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public BaseQuestionRepository( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteQuestion(int questionId, TypeQuestion type) 
        {
            try
            {
                object? question = type switch
                {
                    TypeQuestion.TestQuestion => await _context.TestQuestions.FindAsync(questionId),
                    TypeQuestion.AudioQuestion => await _context.AudioQuestions.FindAsync(questionId),
                    _ => null
                };

                if (question == null) return false;

                _context.Remove(question);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<BaseQuestion?> GetQuestion(int questionId, TypeQuestion type)
        {
            try
            {
                object? question = type switch
                {
                    TypeQuestion.TestQuestion => await _context.TestQuestions.FindAsync(questionId),
                    TypeQuestion.AudioQuestion => await _context.AudioQuestions.FindAsync(questionId),

                    _ => null
                };

                var baseQuestion = question as BaseQuestion;

                if (baseQuestion == null)
                    return null;

                return baseQuestion;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<string?> GetRigthAnswer(int questionId, TypeQuestion type)
        {
            try
            {
                object? question = type switch
                {
                    TypeQuestion.TestQuestion => await _context.TestQuestions
                        .Include(q => q.RightAnswer) 
                        .FirstOrDefaultAsync(q => q.Id == questionId),
                    TypeQuestion.AudioQuestion => await _context.AudioQuestions
                        .FirstOrDefaultAsync(q => q.Id == questionId),

                    _ => null
                };

                return type switch
                {
                    TypeQuestion.TestQuestion => (question as TestQuestion)?.RightAnswer?.RightAnswer,
                    TypeQuestion.AudioQuestion => (question as AudioQuestion)?.RightAnswer,


                    _ => null
                };  
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while getting the right answer.", ex);
            }
        }
    }
}
