using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
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
            if (await _context.LanguageCourses.AnyAsync(c => c.Code == entity.Code) == true) return false;

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
        public async Task<bool> Save()
        {
            try
            {
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

        public async Task<LanguageCourse?> GetById(int id)
        {
            try
            {
                return await _context.LanguageCourses.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbException)
            {
                // Логирование исключения
                return null;
            }
        }
        public async Task<LanguageCourse?> GetCourseByIdWithModule(int courseId)
        {
            return await _context.LanguageCourses
                .Include (c => c.ModulesLessons)
                .FirstOrDefaultAsync (c => c.Id == courseId);
        }

        public async Task<LanguageCourse?> GetCourseByLanguage(string language)
        {
            try
            {
                return await _context.LanguageCourses.FirstOrDefaultAsync(e => e.LanguageName == language);
            }
            catch (Exception)
            {
                // Логирование исключения
                return null;
            }
        }
        public async Task<LanguageCourse?> GetCourseByCode(string code)
        {
            try
            {
                return await _context.LanguageCourses.FirstOrDefaultAsync(e => e.Code == code);
            }
            catch (Exception)
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

        public async Task<IEnumerable<LanguageCourse>> Select()
        {
            return await _context.LanguageCourses.ToListAsync();
        }

        
    }
}
