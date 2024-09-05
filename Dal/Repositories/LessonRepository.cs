
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Domain.Entity.Content.Question;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;

namespace Dal.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _context;

        public LessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Lesson entity)
        {
            if (entity == null || entity.Id == 0) return false;

            try
            {
                await _context.Lessons.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(Lesson entity)
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
        public async Task<Lesson?> Update(Lesson entity)
        {
            if (entity == null) return null;

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return await _context.Lessons.FindAsync(entity.Id);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<Lesson?> GetById(int id)
        {
            try
            {
                return await _context.Lessons.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbException)
            {
                // Логирование исключения
                return null;
            }
        }
        public async Task<bool> AddQuestionToLesson(int lessonId, BaseQuestion entity)
        {
           var lesson = await _context.Lessons
                .Include(l => l.LessonQuestions)
                .FirstOrDefaultAsync(l => l.Id == lessonId);

            if (lesson == null) return false;

            // перевірка чи наше питання вже пов'язане з уроком
            var existigLessonQuestion = await _context.LessonQuestions
                .FirstOrDefaultAsync(lq => lq.LessonId == lessonId && lq.QuestionId == entity.Id);

            if (existigLessonQuestion != null) return false;

            var lessonQuestion = new LessonQuestion
            {
                LessonId = lessonId,
                QuestionId = entity.Id
            };

            try
            {
                await _context.LessonQuestions.AddAsync(lessonQuestion);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteQuestionFromLesson(int lessonId, BaseQuestion entity)
        {
            // перевірка чи наше питання вже пов'язане з уроком
            var lessonQuestion = await _context.LessonQuestions
                .FirstOrDefaultAsync(lq => lq.LessonId == lessonId && lq.QuestionId == entity.Id);

            if (lessonQuestion == null) return false;

            try
            {
                _context.LessonQuestions.Remove(lessonQuestion);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Lesson>> GetLessonByDifficult(LanguageLevel level)
        {
            return await _context.Lessons.Where(c => c.Difficulty == level).ToListAsync();
        }
        public async Task<IEnumerable<Lesson>> Select()
        {
            return await _context.Lessons.ToListAsync();
        }
        public async Task<IEnumerable<BaseQuestion?>> GetAllQuestions(int lessonId)
        {
            var lesson = await _context.Lessons
                .Include(l => l.LessonQuestions)
                .ThenInclude(lq => lq.Question)
                .FirstOrDefaultAsync(l => l.Id == lessonId);

            if(lesson == null) return new List<BaseQuestion>();

            return lesson.LessonQuestions.Select(lq => lq.Question).ToList();
        }
    }
}
