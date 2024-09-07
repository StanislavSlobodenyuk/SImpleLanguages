using Dal.Interfaces;
using Dal.Interfaces.QuestionRepository;
using Dal.Repositories;
using Dal.Repositories.QuestionRepository;


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
            services.AddScoped<IAudioQuestionRepository, AudioQuestionRepository>();
            services.AddScoped<IBaseQuestionRepository, BaseQuestionRepository>();
        }
    }
}
