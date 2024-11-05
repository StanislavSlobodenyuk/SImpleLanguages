
using Dal.Interfaces;
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
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

        public async Task<IEnumerable<BaseQuestion>> GetQuestions(int lessonId)
        {
            var lesson = await _context.Lessons
               .Include(l => l.LessonQuestions)
                   .ThenInclude(lq => lq.AudioQuestion)
                       .ThenInclude(ao => ao.AnswerOptions) // Варианты ответов для аудио-вопросов
      
               .Include(l => l.LessonQuestions)
                   .ThenInclude(lq => lq.TextQuestion)
                       .ThenInclude(ao => ao.AnswerOptions) // Варианты ответов для текстовых вопросов
               .Include(l => l.LessonQuestions)
                   .ThenInclude(lq => lq.TestQuestion)
                       .ThenInclude(ao => ao.AnswerOptions) // Варианты ответов для тестовых вопросов
               .Include(l => l.LessonQuestions)
                   .ThenInclude(lq => lq.ImageQuestion)
                       .ThenInclude(ao => ao.AnswerOptions) // Варианты ответов для вопросов с изображениями
               .FirstOrDefaultAsync(l => l.Id == lessonId);

            if (lesson == null)
            {
                throw new Exception($"Lesson with ID {lessonId} not found.");
            }
            var questions = lesson.LessonQuestions
                .Select(lq => (BaseQuestion?)lq.AudioQuestion ??
                              (BaseQuestion?)lq.TextQuestion ??
                              (BaseQuestion?)lq.TestQuestion ??
                              (BaseQuestion?)lq.ImageQuestion)
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
