using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Metadata.Course;
using Exeption;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Dal.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository( ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task<bool> Add(Course entity)
        {
            if (entity == null || entity.Id == 0) return false;
            if (await _context.Courses.AnyAsync(c => c.Code == entity.Code) == true) return false;

            try
            {
                await _context.Courses.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(Course entity)
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
        public async Task<bool> Update(Course entity)
        {
            if (entity == null) return false;

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

        public async Task<Course?> GetById(int id)
        {
            try
            {
                return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbException)
            {
                // Логирование исключения
                return null;
            }
        }
        public async Task<Course?> GetByLanguageCourse(string language)
        {
            if (string.IsNullOrEmpty(language)) return null;

            try
            {
                return await _context.Courses.FirstOrDefaultAsync(e => e.LanguageName == language);
            }
            catch (Exception)
            {
                // Логирование исключения
                return null;
            }
        }
        public async Task<Course?> GetByCodeCourse(string code)
        {
            if (string.IsNullOrEmpty(code)) return null;
            try
            {
                return await _context.Courses.FirstOrDefaultAsync(e => e.Code == code);
            }
            catch (Exception)
            {
                // Логирование исключения
                return null;
            }
        }
        public async Task<bool> AddModuleToCourse(int courseId, ModuleOfLessons entity)
        {
            Course? course = await _context.Courses
               .Include(c => c.ModulesOfLessons)
               .FirstOrDefaultAsync(e => e.Id == courseId);

            if (course == null || entity == null) return false;

            try
            {
                course.ModulesOfLessons.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> DeleteModuleFromCourse(int courseId, ModuleOfLessons entity)
        {
            Course? course = await _context.Courses
               .Include(c => c.ModulesOfLessons)
               .FirstOrDefaultAsync(e => e.Id == courseId);

            if (course == null || entity == null) return false;

            try
            {
                course.ModulesOfLessons .Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Course>> Select()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
