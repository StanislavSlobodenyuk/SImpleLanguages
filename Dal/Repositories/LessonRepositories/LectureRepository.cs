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
        public async Task<Theory?> GetById(int id)
        {
            try
            {
                Theory? lecture = await _context.Theories.FirstOrDefaultAsync(x => x.Id == id);
                if (lecture == null)
                    return null;

                return lecture;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public async Task<bool> Create(Theory lectureBlock)
        {
            if (lectureBlock == null)
                return false;  

            try
            {
                _context.Theories.Add(lectureBlock);  
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(Theory lectureBlock)
        {
            if (lectureBlock == null)
                return false;

            try
            {
                _context.Theories.Remove(lectureBlock);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Update(Theory lectureBlock)
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
