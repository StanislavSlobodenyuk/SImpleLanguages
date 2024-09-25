using Dal.Interfaces;
using Dal.Interfaces.LessonRepositories;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Enum;
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
                return await _context.Lessons
                .Include(l => l.LectureBlocks)
                .Include(l => l.LessonQuestions)
                    .ThenInclude(q => q.Question)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
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
                    .ThenInclude(q => q.Question)
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

        public async Task<bool> AddLecture(Lesson lesson, LectureBlock lecture)
        {
            if (lecture.LessonId != lesson.Id) return false;

            try
            {
                _context.LectureBlocks.Add(lecture);

                lesson.LectureBlocks.Add(lecture);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteLecture(Lesson lesson, LectureBlock lecture)
        {
            if (lecture.LessonId != lesson.Id) return false;

            try
            {
                lesson.LectureBlocks.Remove(lecture);

                _context.LectureBlocks.Remove(lecture);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public Task<bool> AddQuestionToLesson(Lesson lesson, List<BaseQuestion> question)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteQuestionFromLesson(Lesson lesson, BaseQuestion question)
        {
            //switch (question.Type) 
            //{
            //    case TypeQuestion.TestQuestion:
            //        var testQuestions = question as TestQuestion;
            //        if (testQuestions == null)
            //            return false;
            //        lesson.Questions.Remove(testQuestions);
            //        _context.TestQuestions.Remove(testQuestions);
            //        break;
            //}
            throw new NotImplementedException();
        }
    }
}
