using Dal.Interfaces.LessonRepository;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class LectureRepository : IlectureRepository
    {
        private readonly ApplicationDbContext _context;

        public LectureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(LectureBlock entity)
        {
            if (entity == null)
                return false;  

            try
            {
                _context.Lectures.Add(entity);  
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(LectureBlock entity)
        {
            if (entity == null)
                return false;

            try
            {
                _context.Lectures.Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<LectureBlock?> Update(LectureBlock entity)
        {
            if (entity == null)
                return null;

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<LectureBlock?> GetById(int id)
        {
            try
            {
                LectureBlock? lecture = await _context.Lectures.FirstOrDefaultAsync(x => x.Id == id);
                if (lecture == null)
                    return null;

                return lecture;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
        public async Task<LectureBlock?> UpdateContent(int lectureId, string content)
        {
            if (string.IsNullOrEmpty(content))
                return null;

            try
            {
                LectureBlock? lecture = await _context.Lectures.FirstOrDefaultAsync(x => x.Id == lectureId);

                if (lecture == null)
                    return null;

                lecture.Content = content;

                _context.Entry(lecture).Property(q => q.Content).IsModified = true;
                await _context.SaveChangesAsync();

                return lecture;
            }
            catch (DbUpdateException)
            {

                throw;
            }
        }
        public async Task<LectureBlock?> AddImage(int lectureId, int imageId)
        {
            throw new NotImplementedException();
            // TODO: Доробити  AddImage
        }
        public async Task<LectureBlock?> UpdateImage(int lectureId, string text)
        {
            throw new NotImplementedException();
            // TODO: Доробити  UpdateImage
        }
    }
}
