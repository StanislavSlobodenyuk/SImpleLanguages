using Dal.Interfaces.LearnContent;
using Dal.Interfaces.UserProgress;
using Dal.Repositories.LearnContent;
using Dal.Repositories.UserProgress;
using Domain.Entity.User.UserProgress.TaskResult;
using Service.Implementations.HighLevelServices;
using Service.Implementations.LowLevelServices.AuthorizationServices;
using Service.Implementations.LowLevelServices.LearnContentServices;
using Service.Interfaces.ILowLevelServices.LearnContentService;


namespace Application.InitRepositories
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository >();
            services.AddScoped<ICourseModuleRepository, CourseModuleRepositories>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ITheoryRepository, TheoryRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAchievementRepository, AchievementRepository>();
            services.AddScoped<IUserAchievementRepository, UserAchievementRepository>();
            services.AddScoped<IUserTaskResultRepository<UserTaskResultBase>, UserTaskResultRepository<UserTaskResultBase>>();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseModuleService, CourseModuleService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ITheoryService, TheoryService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<JwtService>();
            services.AddScoped<AuthorizationService>();
        }
    }
}
