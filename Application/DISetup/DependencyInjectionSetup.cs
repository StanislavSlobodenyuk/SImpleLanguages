using Dal.Interfaces;
using Dal.Repositories;

namespace Application.InitRepositories
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IModuleOfLessonsRepository, ModuleOfLessonsRepositories>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ITestQuestionRepository, TestQuestionRepository>();
        }
    }
}
