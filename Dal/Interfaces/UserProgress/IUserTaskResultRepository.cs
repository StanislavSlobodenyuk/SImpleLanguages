
using Domain.Entity.Content.CourseContent;
using Domain.Entity.User.UserProgress.TaskResult;
using Domain.Enum;

namespace Dal.Interfaces.UserProgress
{
    public interface IUserTaskResultRepository<T> where T : UserTaskResultBase
    {
        Task<IEnumerable<UserTaskResultBase>> GetAllUserResultsByCourse(string userId, int courseId);
        Task<IEnumerable<UserTaskResultBase>> GetAllUserResultsByCourseByTaskType(string userId, int courseId, TaskType taskType);

        Task<double> GetPercentageCompletedCourse(string userId, int courseId);
        Task<(Dictionary<string, int> total, Dictionary<string, int> completed)> GetCourseTaskSummary(string userId, int courseId);
       
        Task AddResultByTaskType(string userId, T result, TaskType taskType);
        Task UpdateResultByTaskType(string userId, T newResult, TaskType taskType);
    }
}
