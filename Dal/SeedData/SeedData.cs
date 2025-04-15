using Domain.Entity.Content.CourseContent;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Entity.Content.Question.Answer;
using Domain.Entity.User;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace Dal.SeedData
{
    public static class SeedData
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var role = await roleManager.FindByNameAsync("Admin");
            if (role == null)
            {
                // Создание роли администратора, если она не существует
                var adminRole = new IdentityRole("Admin");
                await roleManager.CreateAsync(adminRole);
            }

            role = await roleManager.FindByNameAsync("User");
            if (role == null)
            {
                var userRole = new IdentityRole("User");
                await roleManager.CreateAsync(userRole);
            }

            var adminUser = await userManager.FindByEmailAsync("stanislav65slobodenyuk@gmail.com");
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "Stanislav_Admin",
                    Email = "stanislav65slobodenyuk@gmail.com",
                    FirstName = "Stanislav",
                    LastName = "Admin",
                    NativeLanguage = LanguageName.All,
                    EmailConfirmed = true,
                };
                // TODO: addHash
                var result = await userManager.CreateAsync(adminUser, "Asdzxc0602");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            if (!context.Courses.Any())
            {
                var courses = new List<Course>
                {
                    new Course{
                        Title = "Основи англійської мови",
                        Description = "Цей курс охоплює основи англійської мови для початківців.",
                        Language = LanguageName.English,
                        Level = LanguageLevel.Beginner,
                        Cost = 0,
                        ImgPath = "https://i.ibb.co/dQgnLF4/About-Service.png"
                    }
                };

                context.Courses.AddRange(courses);
                context.SaveChanges();
            }
        }
    }
}
