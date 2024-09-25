using Dal.Interfaces.LessonRepositories;
using Domain.Entity.Content.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.LessonRepositories
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
                 .Include(c => c.Lessons)
                 .FirstOrDefaultAsync(c => c.Id == moduleId);
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
        public async Task<Lesson?> AddLessonToModule(Lesson lesson, int moduleId)
        {
            CourseModule? module = await _context.CourseModules
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(e => e.Id == moduleId);

            if (module == null || lesson == null)
                return null;

            try
            {
                _context.Lessons.Add(lesson);
                await _context.SaveChangesAsync();

                module.Lessons.Add(lesson);
                await _context.SaveChangesAsync();

                return lesson;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<bool> DeleteLessonFromModule(CourseModule module, Lesson lesson)
        {
            if (module == null || lesson == null) return false;


            try
            {
                module.Lessons.Remove(lesson);
                await _context.SaveChangesAsync();

                _context.Lessons.Remove(lesson);
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
