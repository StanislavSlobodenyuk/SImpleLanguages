
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Dal.Repositories
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public TestQuestionRepository(ApplicationDbContext context) 
        {
            _context = context; 
        }

        public async Task<bool> Create(TestQuestion entity)
        {
            if (entity == null || entity.Id == 0) return false;

            try
            {
                await _context.TestQuestions.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(TestQuestion entity)
        {
            if (entity == null || entity.Id == 0) return false;

            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Save()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<TestQuestion?> Update(TestQuestion entity)
        {
            if (entity == null) return null;

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return await _context.TestQuestions.FindAsync(entity.Id);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<bool> AddTestQuestion(TestQuestion testQuestion, IEnumerable<TestAnswerOption> answerOptions, TestRightAnswer rightAnswer)
        {
            if (testQuestion == null || answerOptions == null || rightAnswer == null) return false;

            foreach (var option in answerOptions)
            {
                testQuestion.AnswerOptions.Add(option);
            }

            testQuestion.RightAnswer = rightAnswer;

            try
            {
                await _context.TestQuestions.AddAsync(testQuestion);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteTestQuestion(TestQuestion testQuestion)
        {
            if (testQuestion == null)
                return false;

            try
            {
                _context.TestQuestions.Remove(testQuestion);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<TestQuestion?> GetById(int questionId)
        {
            var testQuestion = await _context.TestQuestions.FirstOrDefaultAsync(x => x.Id == questionId);

            if (testQuestion == null) return null;
            
            return await _context.TestQuestions
                .Include(q => q.AnswerOptions)
                .Include( q => q.RightAnswer)
                .FirstOrDefaultAsync(q => q.Id == questionId);
        }

        public async Task<IEnumerable<TestQuestion>> Select()
        {
            return await _context.TestQuestions.ToListAsync();
        }
    }
}
