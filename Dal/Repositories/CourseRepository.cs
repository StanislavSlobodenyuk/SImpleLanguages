using Dal.Interfaces;
using Domain.Entity.Content.CourseContent;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;

namespace Dal.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetFillterCourses(string? title, LanguageName language, LanguageLevel level, int[] lessonCount, string? cost, bool inDevelopment)
        {
            try
            {
                List<Course> courses = await _context.Courses.ToListAsync();

                if (!string.IsNullOrEmpty(title))
                {
#pragma warning disable CS8602
                    courses = courses.Where(c => c.Title.Contains(title)).ToList();
#pragma warning restore CS8602
                }

                if (language != LanguageName.All)
                {
                    courses = courses.Where(c => c.Language == language).ToList();
                }

                if (level != LanguageLevel.All)
                {
                    courses = courses.Where(c => c.Level == level).ToList();
                }
                if (lessonCount != null && lessonCount.Length == 2)
                {
                    int minLessons = lessonCount[0];
                    int maxLessons = lessonCount[1];
                    courses = courses.Where(c => c.LessonCount >= minLessons && c.LessonCount <= maxLessons).ToList();
                }

                if (cost != null && cost.ToLower() == "free")
                {
                    courses = courses.Where(c => c.Cost == 0).ToList();
                }
                else if (cost != null && cost.ToLower() == "paid")
                {
                    courses = courses.Where(c => c.Cost > 0).ToList();
                }
                courses = courses.Where(c => c.InDevelopment == inDevelopment).ToList();

                return courses;

            }
            catch (Exception)
            {
                return Enumerable.Empty<Course>();
            }
        }
        public async Task<Course?> GetById(int courseId)
        {
            return await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == courseId);
        }
        public async Task<bool> Create(Course course)
        {
            if (course == null || course.Id == 0) return false;

            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Delete(Course course)
        {
            if (course == null || course.Id == 0) return false;

            try
            {
                _context.Remove(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
        public async Task<bool> Update(Course course)
        {
            try
            {
                _context.Entry(course).State = EntityState.Modified;
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
