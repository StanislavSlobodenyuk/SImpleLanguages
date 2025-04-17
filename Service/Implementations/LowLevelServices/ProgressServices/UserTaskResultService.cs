using Common.Response;
using Domain.Entity.User.UserProgress.TaskResult;
using Service.Interfaces.ILowLevelServices.ProgressService;

namespace Service.Implementations.LowLevelServices.ProgressServices
{
    internal class UserTaskResultService : IUserTaskResultService
    {
        //return new BaseResponse<IEnumerable<UserAchievement>>()
        //           {
        //               Data = null,
        //               Description = "User haven`t achievements",
        //               StatusCode = MyStatusCode.NotFound
        public Task<BaseResponse<IEnumerable<UserTaskResultBase>>> GetAllResultByCourse(string userId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<UserTaskResultBase>>> GetAllResultsInCourseByTaskType(string userId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<(Dictionary<string, int> total, Dictionary<string, int> completed)>> GetCourseTaskSummary(string userId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<double>> GetPercentageCompletedCourse(string userId, int courseId)
        {
            throw new NotImplementedException();
        }
    };
}
