using Dal.Interfaces.LessonRepositories;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Dal.Repositories.LessonRepositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _context;

        public LessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Lesson?> GetById(int lessonId)
        {
            try
            {
                return await _context.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId);
            }
            catch (DbException)
            {
                // Логирование исключения
                return null;
            }
        }
        public async Task<Lesson?> GetLecture(int lessonId)
        {
            return await _context.Lessons
                .Include(l => l.LectureBlocks)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
        }
        public async Task<Lesson?> GetPractice(int lessonId)
        {
            return await _context.Lessons
                .Include(l => l.LessonQuestions)
                    .ThenInclude(q => q.TestQuestion)
                .Include(l => l.LessonQuestions)
                    .ThenInclude(q => q.AudioQuestion)
                .Include(l => l.LessonQuestions)
                    .ThenInclude(q => q.TranslateQuestion)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
        }

        public async Task<bool> Create(Lesson lesson)
        {
            if (lesson == null || lesson.Id == 0) return false;

            try
            {
                await _context.Lessons.AddAsync(lesson);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(Lesson lesson)
        {
            if (lesson == null || lesson.Id == 0) return false;

            try
            {
                _context.Remove(lesson);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> Update(Lesson lesson)
        {
            if (lesson == null) 
                return false;

            try
            {
                _context.Entry(lesson).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<Lesson?> ChangeAvailableLesson(Lesson lesson)
        {
            if( lesson == null)
                return null;

            try
            {
                if (lesson.IsAvailable == true)
                {
                     lesson.IsAvailable = false;
                }
                else { lesson.IsAvailable = true;}

                _context.Entry(lesson).Property(p => p.IsAvailable).IsModified = true;
                await _context.SaveChangesAsync();

                return lesson;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
    }
}
