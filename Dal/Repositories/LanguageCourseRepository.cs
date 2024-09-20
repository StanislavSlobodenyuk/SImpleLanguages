using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Dal.Repositories
{
    public class LanguageCourseRepository : ILanguageCourseRepository
    {
        private readonly ApplicationDbContext _context;

        public LanguageCourseRepository( ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task<bool> Create(LanguageCourse entity)
        {
            if (entity == null || entity.Id == 0) return false;

            try
            {
                await _context.LanguageCourses.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(LanguageCourse entity)
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
        public async Task<bool> Update(LanguageCourse entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<LanguageCourse?> GetById(int courseId)
        {
            try
            {
                return await _context.LanguageCourses
                 .Include(c => c.CourseModules)
                    .ThenInclude(l => l.Lessons)
                 .FirstOrDefaultAsync(c => c.Id == courseId);
            }
            catch (DbException)
            {
                // Логирование исключения
                return null;
            }
        }

        public async Task<CourseModule?> AddModuleToCourse(int courseId, CourseModule module)
        {
            LanguageCourse? course = await _context.LanguageCourses
               .Include(c => c.CourseModules)
               .FirstOrDefaultAsync(e => e.Id == courseId);

            if (course == null || module == null) return null;

            try
            {
                course.CourseModules.Add(module);
                await _context.SaveChangesAsync();
                
                return module;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<bool> DeleteModuleFromCourse(int courseId, int moduleId)
        {
            bool isModuleLinked = await _context.CourseModules
                .AnyAsync(m => m.Id == moduleId && m.LanguageCourseId == courseId);

            if (!isModuleLinked)
                return false;

            try
            {
                CourseModule? currentModule = await _context.CourseModules.FirstOrDefaultAsync(m => m.Id == moduleId);
                
                if (currentModule == null) 
                    return false;

                _context.CourseModules.Remove(currentModule);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<LanguageCourse>> GetCourses(string? name = null, LanguageName? language = null, LanguageLevel? difficulty = null)
        {
            try
            {
                IQueryable<LanguageCourse> query = _context.LanguageCourses
                    .Include(c => c.CourseModules);

                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(c => c.Name != null && c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
                }

                if (language.HasValue)
                {
                    query = query.Where(c => c.Language == language.Value);
                }

                if (difficulty.HasValue)
                {
                    query = query.Where(c => c.Difficult == difficulty.Value);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                return Enumerable.Empty<LanguageCourse>();
            }
        }
    }
}
