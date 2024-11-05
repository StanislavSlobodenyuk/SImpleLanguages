using Dal.Interfaces.CourseDir;
using Dal.Interfaces.LessonRepositories;
using Dal.Repositories;
using Dal.Repositories.CourseDir;
using Dal.Repositories.LessonRepositories;
using Service.Implementations;
using Service.Interfaces;


namespace Application.InitRepositories
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IlectureRepository, LectureRepository>();
            services.AddScoped<ICourseRepository, CourseRepository >();
            services.AddScoped<ICourseModuleRepository, CourseModuleRepositories>();
            services.AddScoped<ILessonRepository, LessonRepository>();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseModuleService, CourseModuleService>();
            services.AddScoped<ILessonService, LessonService>();
        }
    }
}
