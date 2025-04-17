using Dal.Interfaces.LearnContent;
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.LearnContent
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<BaseQuestion?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<object>> GetQuestions(int lessonId)
        {
            var lesson = await _context.Lessons
                .Include(l => l.LessonQuestions)
                    .ThenInclude(lq => lq.AudioQuestion)
                        .ThenInclude(lq => lq.AnswerOptions)
                .Include(l => l.LessonQuestions)
                    .ThenInclude(lq => lq.TextQuestion)
                        .ThenInclude(lq => lq.AnswerOptions)
                .Include(l => l.LessonQuestions)
                    .ThenInclude(lq => lq.SimpleQuestion)
                        .ThenInclude(lq => lq.AnswerOptions)
                .Include(l => l.LessonQuestions)
                    .ThenInclude(lq => lq.ImageQuestion)
                        .ThenInclude(lq => lq.AnswerOptions)
                .FirstOrDefaultAsync(l => l.Id == lessonId);

            if (lesson == null)
            {
                throw new Exception($"Lesson with ID {lessonId} not found.");
            }

            var questions = lesson.LessonQuestions
                .Select(lq => lq.AudioQuestion as object ??
                              lq.TextQuestion as object ??
                              lq.SimpleQuestion as object ??
                              lq.ImageQuestion as object)
                .Where(q => q != null)
                .ToList();

            return questions!;
        }

        public Task<bool> Create(BaseQuestion entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BaseQuestion entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(BaseQuestion entity)
        {
            throw new NotImplementedException();
        }
    }
}
