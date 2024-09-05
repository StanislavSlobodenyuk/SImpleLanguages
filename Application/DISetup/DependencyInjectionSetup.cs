using Dal.Interfaces;
using Dal.Repositories;
using System.Linq.Expressions;

namespace Application.InitRepositories
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ILanguageCourseRepository, LanguageCourseRepository >();
            services.AddScoped<IModuleLessonsRepository, ModuleLessonsRepositories>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ITestQuestionRepository, TestQuestionRepository>();
        }
    }
}
