using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: " Audio_Question",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RightAnswer = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Audio_url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Question_text = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ Audio_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Опис ще не написаний"),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Difficult = table.Column<int>(type: "int", nullable: false),
                    Icon_Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Save_Result = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyImage",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_Path = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test_Question",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RightAnswerId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Question_Text = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translate_Question",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sentense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sentense_Translate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Question_Text = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translate_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course_Module",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Available = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Path_To_Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    LanguageCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseModules_Course_ModuleOfLessons",
                        column: x => x.LanguageCourseId,
                        principalSchema: "dbo",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test_Answer_Option",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer_Option = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TestQuestionId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test_Answer_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestionOptionAnswer_TestQuestion_AnswerOptions",
                        column: x => x.TestQuestionId,
                        principalSchema: "dbo",
                        principalTable: "Test_Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test_Righ_Anwser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Right_Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TestQuestionId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test_Righ_Anwser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestionRigthAnswer_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalSchema: "dbo",
                        principalTable: "Test_Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question_Image",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AudioQuestionId = table.Column<int>(type: "int", nullable: true),
                    TranslateQuestionId = table.Column<int>(type: "int", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionImages_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "MyImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionImages_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "dbo",
                        principalTable: "Test_Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Image_ Audio_Question_AudioQuestionId",
                        column: x => x.AudioQuestionId,
                        principalSchema: "dbo",
                        principalTable: " Audio_Question",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Question_Image_Translate_Question_TranslateQuestionId",
                        column: x => x.TranslateQuestionId,
                        principalSchema: "dbo",
                        principalTable: "Translate_Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Is_Available = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Icon_Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleLessonsId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModulesLessons_Lesson_ModuleOfLessons",
                        column: x => x.ModuleLessonsId,
                        principalTable: "Course_Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecture",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonLectureBlock_Lesson_LectureBlock",
                        column: x => x.LessonId,
                        principalSchema: "dbo",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lesson_Question",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    TestQuestionId = table.Column<int>(type: "int", nullable: false),
                    AudioQuestionId = table.Column<int>(type: "int", nullable: false),
                    TranslateQuestionId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonAudioQuestions_LessonQuestions",
                        column: x => x.AudioQuestionId,
                        principalSchema: "dbo",
                        principalTable: " Audio_Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonQuestions_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "dbo",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonTestQuestions_LessonQuestions",
                        column: x => x.TestQuestionId,
                        principalSchema: "dbo",
                        principalTable: "Test_Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranslateQuestion_LessonQuestions",
                        column: x => x.TestQuestionId,
                        principalSchema: "dbo",
                        principalTable: "Translate_Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lecture_Image",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectureId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturesImages_ImageId",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "MyImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LecturesImages_LectureId",
                        column: x => x.LectureId,
                        principalSchema: "dbo",
                        principalTable: "Lecture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Module_LanguageCourseId",
                table: "Course_Module",
                column: "LanguageCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_LessonId",
                schema: "dbo",
                table: "Lecture",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Image_ImageId",
                schema: "dbo",
                table: "Lecture_Image",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Image_LectureId",
                schema: "dbo",
                table: "Lecture_Image",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ModuleLessonsId",
                schema: "dbo",
                table: "Lesson",
                column: "ModuleLessonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Question_AudioQuestionId",
                schema: "dbo",
                table: "Lesson_Question",
                column: "AudioQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Question_LessonId",
                schema: "dbo",
                table: "Lesson_Question",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Question_TestQuestionId",
                schema: "dbo",
                table: "Lesson_Question",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Image_AudioQuestionId",
                schema: "dbo",
                table: "Question_Image",
                column: "AudioQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Image_ImageId",
                schema: "dbo",
                table: "Question_Image",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Image_QuestionId",
                schema: "dbo",
                table: "Question_Image",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Image_TranslateQuestionId",
                schema: "dbo",
                table: "Question_Image",
                column: "TranslateQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_Answer_Option_TestQuestionId",
                schema: "dbo",
                table: "Test_Answer_Option",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_Righ_Anwser_TestQuestionId",
                schema: "dbo",
                table: "Test_Righ_Anwser",
                column: "TestQuestionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Lecture_Image",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Lesson_Question",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Question_Image",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Test_Answer_Option",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Test_Righ_Anwser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Lecture",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MyImage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: " Audio_Question",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Translate_Question",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Test_Question",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Lesson",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Course_Module");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "dbo");
        }
    }
}
