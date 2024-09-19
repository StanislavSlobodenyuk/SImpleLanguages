using Dal.Interfaces.LessonRepository;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

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
        public async Task<Lesson?> UpdateIcon(Lesson lesson, string iconPath)
        {
            try
            {
                lesson.IconPath  = iconPath;    
                _context.Entry(lesson).Property(p => p.IconPath).IsModified = true;
                
                await _context.SaveChangesAsync();

                return lesson;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<Lesson?> UpdateTitle(Lesson lesson, string title)
        {
            try
            {
                lesson.Title = title;
                _context.Entry(lesson).Property(p => p.Title).IsModified = true;
     
                await _context.SaveChangesAsync();

                return lesson;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<Lesson?> ChangeAvailableLesson(Lesson lesson, bool isAvailable)
        {
            try
            {
                lesson.IsAvailable = isAvailable;

                _context.Entry(lesson).Property(p => p.IsAvailable).IsModified = true;
                await _context.SaveChangesAsync();

                return lesson;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<Lesson?> GetById(int lessonId)
        {
            try
            {
                return await _context.Lessons
                .Include(l => l.LectureBlocks)
                .Include(l => l.LessonQuestions)
                    .ThenInclude(lq => lq.Question)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
            }
            catch (DbException)
            {
                // Логирование исключения
                return null;
            }
        }

        public async Task<Lesson?> AddQuestionToLesson(int lessonId, BaseQuestion entity)
        {
            Lesson? lesson = await GetById(lessonId);

            if (lesson == null) return null;

            var existigLessonQuestion = await _context.LessonQuestions
                .FirstOrDefaultAsync(lq => lq.LessonId == lessonId && lq.QuestionId == entity.Id);

            if (existigLessonQuestion != null) return null ;

            var lessonQuestion = new LessonQuestion
            {
                LessonId = lessonId,
                QuestionId = entity.Id
            };

            try
            {
                await _context.LessonQuestions.AddAsync(lessonQuestion);
                await _context.SaveChangesAsync();

                return await _context.Lessons
                    .Include(l => l.LessonQuestions)
                    .FirstOrDefaultAsync(l => l.Id == lessonId);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<bool?> DeleteQuestionFromLesson(int lessonId, BaseQuestion entity)
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

        public async Task<Lesson?> AddLecture(int lessonId, LectureBlock lecture)
        {
            Lesson? lesson = await GetById(lessonId);

            if (lesson == null)  
                return null;

            if (lecture.LessonId == lesson.Id) return null;

            try
            {
                lesson.LectureBlocks.Add(lecture);
                await _context.SaveChangesAsync();

                return await _context.Lessons
                .Include(l => l.LectureBlocks)
                .Include(l => l.LessonQuestions)
                    .ThenInclude(lq => lq.Question)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<bool?> DeleteLecture(int lesssonId, LectureBlock lecture)
        {
            if (lecture == null)
                return false;

            Lesson? currentLesson = await _context.Lessons.FirstOrDefaultAsync(e => e.Id == lesssonId);

            if (currentLesson == null)
                return false;
            try
            {
                currentLesson.LectureBlocks.Remove(lecture);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<BaseQuestion?>> GetAllQuestions(int lessonId)
        {
            var lesson = await _context.Lessons
        .Include(l => l.LessonQuestions)
            .ThenInclude(lq => lq.Question)
        .FirstOrDefaultAsync(l => l.Id == lessonId);

            if (lesson == null) return new List<BaseQuestion>();

            foreach (var lessonQuestion in lesson.LessonQuestions)
            {
                if (lessonQuestion.Question is TestQuestion testQuestion)
                {
                    await _context.Entry(testQuestion)
                        .Collection(tq => tq.AnswerOptions)
                        .LoadAsync();
                }
            }

            return lesson.LessonQuestions
                .Select(lq => lq.Question)
                .ToList();
        }
    }
}
