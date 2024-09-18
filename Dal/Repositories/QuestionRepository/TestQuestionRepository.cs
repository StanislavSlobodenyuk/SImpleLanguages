
using Dal.Interfaces.QuestionRepository;
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.QuestionRepository
{
    public class TestQuestionRepository : ITestQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public TestQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTestQuestion(TestQuestion testQuestion, IEnumerable<TestAnswerOption> answerOptions, TestRightAnswer rightAnswer)
        {
            if (testQuestion == null || rightAnswer == null || answerOptions.Any(aq => aq == null))
                return false;
            try
            {
                var newQuestion = new TestQuestion(testQuestion.QuestionText, testQuestion.Type);
                
                newQuestion.AnswerOptions = new List<TestAnswerOption>(answerOptions);
                newQuestion.RightAnswer = rightAnswer;

                await _context.TestQuestions.AddAsync(newQuestion);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<TestQuestion?> UpdateAnswerOptions(int testQuestionId, IEnumerable<TestAnswerOption> answerOptions)
        {
            if (answerOptions.Any(aq => aq == null))
                return null;
            try
            {
                var question = await _context.TestQuestions.FirstOrDefaultAsync(q => q.Id == testQuestionId);

                if (question == null)
                    return null;

                question.AnswerOptions = new List<TestAnswerOption>(answerOptions);

                _context.Entry(question).Property(q => q.AnswerOptions).IsModified = true;
                await _context.SaveChangesAsync();

                return question;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<TestQuestion?> UpdateRightAnswer(int testQuestionId, TestRightAnswer rightAnswer)
        {
            if (rightAnswer == null)
                return null;
            try
            {
                var question = await _context.TestQuestions.FirstOrDefaultAsync(q => q.Id == testQuestionId);

                if (question == null)
                    return null;

                question.RightAnswer = rightAnswer; 

                _context.Entry(question).Property(q => q.RightAnswer).IsModified = true;
                await _context.SaveChangesAsync();

                return question;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<TestQuestion?> UpdateQuestionText(int testQuestionId, string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;
            try
            {
                var question = await _context.TestQuestions.FirstOrDefaultAsync(q => q.Id == testQuestionId);

                if (question == null)
                    return null;

                question.QuestionText = text;

                _context.Entry(question).Property(q => q.QuestionText).IsModified = true;
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
