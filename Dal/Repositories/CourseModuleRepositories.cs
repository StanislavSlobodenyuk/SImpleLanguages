using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class CourseModuleRepositories : ICourseModuleRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseModuleRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CourseModule?> GetById(int moduleId)
        {
            return await _context.CourseModules
                 .FirstOrDefaultAsync(c => c.Id == moduleId);
        }
        public async Task<IEnumerable<CourseModule>> GetModules(int courseId)
        {
            return await _context.CourseModules
                .Where(cm => cm.CourseId == courseId)
                .Include(l => l.Lessons)
                .ToListAsync();
        }

        public async Task<bool> Create(CourseModule module)
        {
            if (module == null || module.Id == 0) return false;

            try
            {
                await _context.CourseModules.AddAsync(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(CourseModule module)
        {
            if (module == null || module.Id == 0) return false;

            try
            {
                _context.Remove(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Update(CourseModule module)
        {
            try
            {
                _context.Entry(module).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> ChangeAvailableModule(CourseModule module)
        {
            if (module == null) return false;

            try
            {
                if (module.IsAvailable == true)
                {
                    module.IsAvailable = false;
                }
                else { module.IsAvailable = true; }

                _context.Entry(module).State = EntityState.Modified;
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
