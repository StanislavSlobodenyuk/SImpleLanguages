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
        public async Task<LanguageCourse?> Update(LanguageCourse entity)
        {
            if (entity == null) return null;

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return await _context.LanguageCourses.FindAsync(entity.Id);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<LanguageCourse?> GetById(int courseId)
        {
            try
            {
                return await _context.LanguageCourses
                 .Include(c => c.ModulesLessons)
                 .FirstOrDefaultAsync(c => c.Id == courseId);
            }
            catch (DbException)
            {
                // Логирование исключения
                return null;
            }
        }

        public async Task<ModuleLessons?> AddModuleToCourse(int courseId, ModuleLessons entity)
        {
            LanguageCourse? course = await _context.LanguageCourses
               .Include(c => c.ModulesLessons)
               .FirstOrDefaultAsync(e => e.Id == courseId);

            if (course == null || entity == null) return null;

            try
            {
                course.ModulesLessons.Add(entity);
                await _context.SaveChangesAsync();
                
                var module =  course.ModulesLessons.FirstOrDefault(m => m == entity);

                return module;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<bool> DeleteModuleFromCourse(int courseId, ModuleLessons entity)
        {
            LanguageCourse? course = await _context.LanguageCourses
               .Include(c => c.ModulesLessons)
               .FirstOrDefaultAsync(e => e.Id == courseId);

            if (course == null || entity == null) return false;

            try
            {
                course.ModulesLessons .Remove(entity);
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
                    .Include(c => c.ModulesLessons);

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
