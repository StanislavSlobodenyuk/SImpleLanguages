using Dal.Interfaces;
using Dal.Repositories;
using Service.AuthorizationService;
using Service.Implementations;
using Service.Interfaces;
using Service.JWTService;


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
