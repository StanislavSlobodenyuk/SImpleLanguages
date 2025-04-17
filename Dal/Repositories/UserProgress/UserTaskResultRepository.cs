using Dal.Interfaces.UserProgress;
using Domain.Entity.User.UserProgress.TaskResult;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories.UserProgress
{
    public class UserTaskResultRepository<T> : IUserTaskResultRepository<T> where T : UserTaskResultBase
    {
        private readonly ApplicationDbContext _context;

        public UserTaskResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<UserTaskResultBase>> GetAllUserResultsByCourse(string userId, int courseId)
        {
            var result = new List<UserTaskResultBase>();

            var lessonResult = await _context.UserLessonResults
                .Include(x => x.Lesson)
                    .ThenInclude(l => l.CourseModules)
                .Where(x => x.UserId == userId && x.Lesson.CourseModules!.CourseId == courseId)
                .ToListAsync();
            result.AddRange(lessonResult);

            var grammarResult = await _context.UserGrammarResults
                .Include(x => x.Grammar)
                .Where(x => x.UserId == userId && x.Grammar.CourseId == courseId)
                .ToListAsync();
            result.AddRange(grammarResult);

            var storyResult = await _context.UserStoryResults
                .Include(x => x.Story)
                .Where(x => x.UserId == userId && x.Story.CourseId == courseId)
                .ToListAsync();
            result.AddRange(storyResult);

            return result;
        }
        public async Task<IEnumerable<UserTaskResultBase>> GetAllUserResultsByCourseByTaskType(string userId, int courseId, TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.Lesson:
                    return await _context.UserLessonResults
                        .Include(x => x.Lesson)
                            .ThenInclude(l => l.CourseModules)
                        .Where(x => x.UserId == userId && x.Lesson.CourseModules!.CourseId == courseId)
                        .ToListAsync();

                case TaskType.Grammar:
                    return await _context.UserGrammarResults
                        .Include(x => x.Grammar)
                        .Where(x => x.UserId == userId && x.Grammar.CourseId == courseId)
                        .ToListAsync();

                case TaskType.Story:
                    return await _context.UserStoryResults
                       .Include(x => x.Story)
                       .Where(x => x.UserId == userId && x.Story.CourseId == courseId)
                       .ToListAsync();
                default:
                    throw new ArgumentException("Invalid TaskType", nameof(taskType));
            }
        }

        public async Task<double> GetPercentageCompletedCourse(string userId, int courseId)
        {
            var (total, completed) = await GetCourseTaskSummary(userId, courseId);

            var totalTasks = total["lessons"] + total["grammars"] + total["stories"] + total["words"];
            var completedTasks = completed["lessons"] + completed["grammars"] + completed["stories"] + completed["words"];

            if (totalTasks == 0)
                return 0;

            return (double)completedTasks / totalTasks * 100;
        }
        public async Task<(Dictionary<string, int> total, Dictionary<string, int> completed)> GetCourseTaskSummary(string userId, int courseId)
        {
            var course = await _context.Courses
                .Include(c => c.CourseModules)
                    .ThenInclude(cm => cm.Lessons)
                .Include(c => c.Grammars)
                .Include(c => c.Stories)
                .Include(c => c.CourseWords)
                .FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null)
                throw new InvalidOperationException("Course not found");

            var totalCounts = new Dictionary<string, int>
            {
                { "lessons", course.CourseModules.Sum(cm => cm.Lessons.Count) },
                { "grammars", course.Grammars.Count },
                { "stories", course.Stories.Count },
                { "words", course.CourseWords.Count }
            };

            var userResults = await GetAllUserResultsByCourse(userId, courseId);

            var completedCounts = new Dictionary<string, int>
            {
                { "lessons", userResults.OfType<UserLessonResult>().Where(x => x.IsCompleted && x.Score >= 75).GroupBy(x => x.LessonId).Count() },
                { "grammars", userResults.OfType<UserGrammarResult>().Where(x => x.IsCompleted && x.Score >= 75).GroupBy(x => x.GrammarId).Count() },
                { "stories", userResults.OfType<UserStoryResult>().Where(x => x.IsCompleted && x.Score >= 75).GroupBy(x => x.StoryId).Count() },
                { "words", 0 }
            };

            return (totalCounts, completedCounts);
        }

        public async Task AddResultByTaskType(string userId, T result, TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.Lesson:
                    await _context.UserLessonResults.AddAsync((UserLessonResult)(object)result);
                    break;
                case TaskType.Grammar:
                    await _context.UserGrammarResults.AddAsync((UserGrammarResult)(object)result);
                    break;
                case TaskType.Story:
                    await _context.UserStoryResults.AddAsync((UserStoryResult)(object)result);
                    break;
                default:
                    throw new ArgumentException("Invalid TaskType", nameof(taskType));
            }
            await _context.SaveChangesAsync();
        }
        public async Task UpdateResultByTaskType(string userId, T newResult, TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.Lesson:
                    _context.UserLessonResults.Update((UserLessonResult)(object)newResult);
                    break;
                case TaskType.Grammar:
                    _context.UserGrammarResults.Update((UserGrammarResult)(object)newResult);
                    break;
                case TaskType.Story:
                    _context.UserStoryResults.Update((UserStoryResult)(object)newResult);
                    break;
                default:
                    throw new ArgumentException("Invalid TaskType", nameof(taskType));
            }

            await _context.SaveChangesAsync();
        }
    }
}
