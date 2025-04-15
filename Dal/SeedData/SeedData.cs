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

            if (!context.CourseModules.Any())
            {
                var courseModules = new List<CourseModule>
                {
                    new CourseModule
                    {
                        Title = "Основи англійської мови",
                        PathToMap = "https://i.ibb.co/gRT0pTL/map.png",
                        IsAvailable = true,
                        CourseId = 1
                    },
                    new CourseModule
                    {
                        Title = "Лексика та словниковий запас",
                        PathToMap = "https://i.ibb.co/gRT0pTL/map.png",
                        IsAvailable = true,
                        CourseId = 1
                    },
                    new CourseModule
                    {
                        Title = "Граматика на прикладах",
                        PathToMap = "https://i.ibb.co/gRT0pTL/map.png",
                        IsAvailable = true,
                        CourseId = 1
                    },
                    new CourseModule
                    {
                        Title = "Слухання та вимова",
                        PathToMap = "https://i.ibb.co/gRT0pTL/map.png",
                        IsAvailable = true,
                        CourseId = 1
                    },
                    new CourseModule
                    {
                        Title = "Читання та письмо",
                        PathToMap = "https://i.ibb.co/gRT0pTL/map.png",
                        IsAvailable = true,
                        CourseId = 1
                    },
                    new CourseModule
                    {
                        Title = "Практика та повторення",
                        PathToMap = "https://i.ibb.co/gRT0pTL/map.png",
                        IsAvailable = true,
                        CourseId = 1
                    },

                };

                context.CourseModules.AddRange(courseModules);
                context.SaveChanges();
            }

            if (!context.Lessons.Any())
            {
                var lessons = new List<Lesson>
                {
                    // Для первого модуля
                    new Lesson { Title = "Вступ до граматики", IsAvailable = true, CourseModuleId = 1 },
                    new Lesson { Title = "Основні слова та фрази", IsAvailable = true, CourseModuleId = 1 },
                    new Lesson { Title = "Вживання дієслів", IsAvailable = true, CourseModuleId = 1 },
                    new Lesson { Title = "Часи в англійській", IsAvailable = true, CourseModuleId = 1 },
                    new Lesson { Title = "Запитання та відповіді", IsAvailable = true, CourseModuleId = 1 },
                    new Lesson { Title = "Короткі речення", IsAvailable = true, CourseModuleId = 1 },

                    // Для второго модуля
                    new Lesson { Title = "Повсякденні слова", IsAvailable = true, CourseModuleId = 2 },
                    new Lesson { Title = "Теми: їжа", IsAvailable = true, CourseModuleId = 2 },
                    new Lesson { Title = "Теми: подорожі", IsAvailable = true, CourseModuleId = 2 },
                    new Lesson { Title = "Теми: погода", IsAvailable = true, CourseModuleId = 2 },
                    new Lesson { Title = "Антоніми та синоніми", IsAvailable = true, CourseModuleId = 2 },
                    new Lesson { Title = "Вивчення фраз", IsAvailable = true, CourseModuleId = 2 },

                    // Для третьего модуля
                    new Lesson { Title = "Структура речень", IsAvailable = true, CourseModuleId = 3 },
                    new Lesson { Title = "Вживання артиклів", IsAvailable = true, CourseModuleId = 3 },
                    new Lesson { Title = "Прийменники", IsAvailable = true, CourseModuleId = 3 },
                    new Lesson { Title = "Прикметники та прислівники", IsAvailable = true, CourseModuleId = 3 },
                    new Lesson { Title = "Заперечення", IsAvailable = true, CourseModuleId = 3 },
                    new Lesson { Title = "Складні речення", IsAvailable = true, CourseModuleId = 3 },

                    // Для четвертого модуля
                    new Lesson { Title = "Вимова звуків", IsAvailable = true, CourseModuleId = 4 },
                    new Lesson { Title = "Слухові вправи", IsAvailable = true, CourseModuleId = 4 },
                    new Lesson { Title = "Аудіо вправи", IsAvailable = true, CourseModuleId = 4 },
                    new Lesson { Title = "Розуміння на слух", IsAvailable = true, CourseModuleId = 4 },
                    new Lesson { Title = "Повторення фраз", IsAvailable = true, CourseModuleId = 4 },
                    new Lesson { Title = "Діалоги", IsAvailable = true, CourseModuleId = 4 },

                    // Для пятого модуля
                    new Lesson { Title = "Читання текстів", IsAvailable = true, CourseModuleId = 5 },
                    new Lesson { Title = "Написання речень", IsAvailable = true, CourseModuleId = 5 },
                    new Lesson { Title = "Огляд граматики", IsAvailable = true, CourseModuleId = 5 },
                    new Lesson { Title = "Складення історій", IsAvailable = true, CourseModuleId = 5 },
                    new Lesson { Title = "Анотації", IsAvailable = true, CourseModuleId = 5 },
                    new Lesson { Title = "Есе", IsAvailable = true, CourseModuleId = 5 },

                    // Для шестого модуля
                    new Lesson { Title = "Повторення граматики", IsAvailable = true, CourseModuleId = 6 },
                    new Lesson { Title = "Розмовна практика", IsAvailable = true, CourseModuleId = 6 },
                    new Lesson { Title = "Пробні тести", IsAvailable = true, CourseModuleId = 6 },
                    new Lesson { Title = "Вправи на повторення", IsAvailable = true, CourseModuleId = 6 },
                    new Lesson { Title = "Групова робота", IsAvailable = true, CourseModuleId = 6 },
                    new Lesson { Title = "Зворотній зв'язок", IsAvailable = true, CourseModuleId = 6 }

                };

                context.Lessons.AddRange(lessons);
                context.SaveChanges();
            }

            if (!context.AudioQuestions.Any() && !context.SimpleQuestions.Any() && !context.TextQuestions.Any() && !context.PictureQuestions.Any())
            {
                List<AudioQuestion> audioQuestionList = new List<AudioQuestion>
                {
                    new AudioQuestion
                    {
                        QuestionText = "Прослухайте та дайте відповідь на питання",
                        QType = QuestionType.AudioQuestion,
                        AType = AnswerType.Radio,
                        AudioPath = "/src/audioTest/testSound.mp3",
                    },
                };
                List<SimpleQuestion> testQuestionList = new List<SimpleQuestion>
                {
                    new SimpleQuestion
                    {
                        QuestionText = "Який переклад слова \"family\"",
                        QType = QuestionType.SimpleQuestion,
                        AType = AnswerType.Radio
                    },
                    new SimpleQuestion
                    {
                        QuestionText = " Напишіть 5 речень про себе використовуючи слова які вивчили в цьому уроці",
                        QType = QuestionType.SimpleQuestion,
                        AType = AnswerType.Writing
                    }
                };
                List<TextQuestion> textQuestionList = new List<TextQuestion>
                {
                    new TextQuestion
                    {
                        QuestionText = "Що подобається Анні?",
                        QType = QuestionType.TextQuestion,
                        AType = AnswerType.CheckBox,
                        Text = "Anna likes to read books. She reads every day after school. Her favorite book is about animals. She also loves to draw pictures of her favorite animals. Anna wants to become a vet and help animals when she grows up."
                    }
                };
                List<PictureQuestion> imageQuestionList = new List<PictureQuestion>
                {
                    new PictureQuestion
                    {
                        QuestionText = "хХто зображений на малюнку",
                        QType = QuestionType.ImageQuestion,
                        AType = AnswerType.Input,
                        ImagePath = "/src/img/Content/cat.png",
                    },
                };

                context.AudioQuestions.AddRange(audioQuestionList);
                context.SimpleQuestions.AddRange(testQuestionList);
                context.TextQuestions.AddRange(textQuestionList);
                context.PictureQuestions.AddRange(imageQuestionList);
                context.SaveChanges();
            }

            if (!context.Theories.Any())
            {
                List<Theory> theories = new List<Theory>
                {
                    new Theory
                    {
                        Title = "Початок вивчення англійської мови",
                        TextContent = "Тут дуже багато контенту про англійську мову і все інше тут дуже багато контенту " +
                        "про англійську мову і все інше  тут дуже багато контенту про англійську мову і все інше тут дуже " +
                        "багато контенту про англійську мову і все інше  тут дуже багато контенту про англійську мову і все " +
                        "інше",
                        ListContent = new List<string>{ },
                        ImagePath = null,
                        Type = TheoryType.Text,
                        LessonId = 1,
                    },
                    new Theory
                    {
                        Title = "У англійській мові є три основні часові форми: минулий, теперішній та майбутній часи. Кожен з них має просту, тривалу, досконалу і досконалу тривалу форму.",
                        TextContent = null,
                        ListContent = new List<string>
                        {
                            "Теперішній час (Present): I play (Я граю)",
                            "Минулий час (Past): I played (Я грав)",
                            "Майбутній час (Future): I will play (Я буду грати)"
                        },
                        ImagePath = null,
                        Type = TheoryType.List,
                        LessonId = 1,
                    },
                    new Theory
                    {
                        Title = "Початок вивчення англійської мови",
                        TextContent = null,
                        ListContent = new List<string>{ },
                        ImagePath = "https://i.ibb.co/dQgnLF4/About-Service.png",
                        Type = TheoryType.Text,
                        LessonId = 1,
                    }
                };
                context.Theories.AddRange(theories);
                context.SaveChanges();
            }

            if (!context.LessonQuestions.Any())
            {
                List<LessonQuestion> lessonQuestions = new List<LessonQuestion>()
                {
                    new LessonQuestion
                    {
                        LessonId = 1,
                        AudioQuestionId = 1,
                    },
                    new LessonQuestion
                    {
                        LessonId = 1,
                        SimpleQuestionId = 1,
                    },
                    new LessonQuestion
                    {
                        LessonId = 1,
                        SimpleQuestionId = 2,
                    },
                    new LessonQuestion
                    {
                        LessonId = 1,
                        TextQuestionId = 1,
                    },
                    new LessonQuestion
                    {
                        LessonId = 1,
                        ImageQuestionId = 1,
                    },
                };
                context.LessonQuestions.AddRange(lessonQuestions);
                context.SaveChanges();
            }

            if (!context.AnswerOptions.Any())
            {
                List<AnswerOption> answerOptions = new List<AnswerOption>()
                {
                    new AnswerOption
                    {
                        AudioQuestionId = 1,
                        Option = "Hello my name`s Den"
                    },
                    new AnswerOption
                    {
                        AudioQuestionId = 1,
                        Option = "Good evening Den"
                    },
                    new AnswerOption
                    {
                        AudioQuestionId = 1,
                        Option = "Bye Den"
                    },
                    new AnswerOption
                    {
                        AudioQuestionId = 1,
                        Option = "How are you Den?"
                    },
                    new AnswerOption
                    {
                        SimpleQuestionId = 1,
                        Option = "Сім\'я"
                    },
                    new AnswerOption
                    {
                        SimpleQuestionId = 1,
                        Option = "Дерево"
                    },
                    new AnswerOption
                    {
                        SimpleQuestionId = 1,
                        Option = "Батько"
                    },
                    new AnswerOption
                    {
                        SimpleQuestionId = 1,
                        Option = "Мати"
                    },
                    new AnswerOption
                    {
                        TextQuestionId = 1,
                        Option = "Play soccer"
                    },
                    new AnswerOption
                    {
                        TextQuestionId = 1,
                        Option = "Read books"
                    },
                    new AnswerOption
                    {
                        TextQuestionId = 1,
                        Option = "Draw pictures"
                    },
                    new AnswerOption
                    {
                        TextQuestionId = 1,
                        Option = "Cook food"
                    },
                    new AnswerOption
                    {
                        TextQuestionId = 1,
                        Option = "Sing songs"
                    },
                    new AnswerOption
                    {
                        ImageQuestionId = 1,
                        Option = "InputType"
                    },
                };

                context.AnswerOptions.AddRange(answerOptions);
                context.SaveChanges();
            }

            if (!context.RightAnswers.Any())
            {
                List<RightAnswer> rightAnswers = new List<RightAnswer>()
                {
                    new RightAnswer
                    {
                        AudioQuestionId = 1,
                        Answer = "Hello my name`s Den"
                    },
                    new RightAnswer
                    {
                        SimpleQuestionId = 1,
                        Answer = "Сім\'я"
                    },
                    new RightAnswer
                    {
                        TextQuestionId = 1,
                        Answer = "Read books"
                    },
                    new RightAnswer
                    {
                        TextQuestionId = 1,
                        Answer = "Draw pictures"
                    },
                    new RightAnswer
                    {
                        ImageQuestionId = 1,
                        Answer = "Cat"
                    },
                };

                context.RightAnswers.AddRange(rightAnswers);
                context.SaveChanges();
            }
        }
    }
}
