using Dal.Interfaces;
using Dal.Interfaces.LessonRepositories;
using Domain.Entity.Content.Lessons;
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
        public async Task<LectureBlock?> GetById(int id)
        {
            try
            {
                LectureBlock? lecture = await _context.LectureBlocks.FirstOrDefaultAsync(x => x.Id == id);
                if (lecture == null)
                    return null;

                return lecture;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public async Task<bool> Create(LectureBlock lectureBlock)
        {
            if (lectureBlock == null)
                return false;  

            try
            {
                _context.LectureBlocks.Add(lectureBlock);  
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(LectureBlock lectureBlock)
        {
            if (lectureBlock == null)
                return false;

            try
            {
                _context.LectureBlocks.Remove(lectureBlock);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Update(LectureBlock lectureBlock)
        {
            if (lectureBlock == null)
                return false;

            try
            {
                _context.Entry(lectureBlock).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}
