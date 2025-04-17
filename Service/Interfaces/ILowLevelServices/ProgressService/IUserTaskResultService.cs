using Common.Response;
using Domain.Entity.User.UserProgress.TaskResult;

namespace Service.Interfaces.ILowLevelServices.ProgressService
{
    public interface IUserTaskResultService
    {
        Task<BaseResponse<IEnumerable<UserTaskResultBase>>> GetAllResultByCourse(string userId, int courseId);
        Task<BaseResponse<IEnumerable<UserTaskResultBase>>> GetAllResultsInCourseByTaskType(string userId, int courseId);
        Task<BaseResponse<double>> GetPercentageCompletedCourse(string userId, int courseId);
        Task<BaseResponse<(Dictionary<string, int> total, Dictionary<string, int> completed)>> GetCourseTaskSummary(string userId, int courseId);
    }
}
