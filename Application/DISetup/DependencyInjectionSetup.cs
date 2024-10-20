﻿using Dal.Interfaces;
using Dal.Interfaces.LessonRepositories;
using Dal.Interfaces.QuestionRepository;
using Dal.Repositories;
using Dal.Repositories.LessonRepositories;
using Dal.Repositories.QuestionRepository;
using Service.Implementations;
using Service.Interfaces;


namespace Application.InitRepositories
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IlectureRepository, LectureRepository>();
            services.AddScoped<ILanguageCourseRepository, LanguageCourseRepository >();
            services.AddScoped<ICourseModuleRepository, CourseModuleRepositories>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ITestQuestionRepository, TestQuestionRepository>();
            services.AddScoped<IAudioQuestionRepository, AudioQuestionRepository>();
            services.AddScoped<IBaseQuestionRepository, BaseQuestionRepository>();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILanguageCourseService, LanguageCourseService>();
            services.AddScoped<ICourseModuleService, CourseModuleService>();
            services.AddScoped<ILessonService, LessonService>();
        }
    }
}
