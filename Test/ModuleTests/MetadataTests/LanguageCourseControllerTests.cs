using Xunit;
using Moq;
using Application.Controllers;
using Dto;
using Service.Interfaces;
using Common.Response;
using Domain.Entity.Content.Metadata.Course;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity.Content.Lessons;
using Domain.Enum;

namespace Test.XUnitTests.MetadataTests
{
    [Collection("Language Course Tests")]
    public class LanguageCourseControllerTests
    {
        // Assert
        protected readonly CourseController _controller;
        protected readonly Mock<ILanguageCourseService> _mockService;
        protected readonly CourseFilterDto _filterDto;
        protected readonly UpdateCourseDto _updateCourseDto;

        public LanguageCourseControllerTests()
        {
            _mockService = new Mock<ILanguageCourseService>();
            _controller = new CourseController(_mockService.Object);
            _filterDto = new CourseFilterDto();
            _updateCourseDto = new UpdateCourseDto();
        }

        [Theory]
        [InlineData(200, "GetCourseById")] // GetCourseById
        [InlineData(400, "GetCourseById")]
        [InlineData(404, "GetCourseById")]
        [InlineData(500, "GetCourseById")]
        [InlineData(200, "CreateCourse")] // CreateCourse
        [InlineData(400, "CreateCourse")]
        [InlineData(500, "CreateCourse")]
        [InlineData(200, "DeleteCourse")] // DeleteCourse
        [InlineData(400, "DeleteCourse")]
        [InlineData(404, "DeleteCourse")]
        [InlineData(500, "DeleteCourse")]
        [InlineData(200, "UpdateCourse")] // UpdateCourse
        [InlineData(400, "UpdateCourse")]
        [InlineData(404, "UpdateCourse")]
        [InlineData(500, "UpdateCourse")]
        [InlineData(200, "AddModule")] // AddModule
        [InlineData(400, "AddModule")]
        [InlineData(500, "AddModule")]
        [InlineData(200, "DeleteModule")] // DeleteModule
        [InlineData(400, "DeleteModule")]
        [InlineData(404, "DeleteModule")]
        [InlineData(500, "DeleteModule")]
        [InlineData(200, "GetFillterCourses")] // GetFillterCourses
        [InlineData(400, "GetFillterCourses")]
        [InlineData(404, "GetFillterCourses")]
        [InlineData(500, "GetFillterCourses")]
        public async Task Test_BadResponse_For_DifferentMethods(int expectedStatusCode, string methodName)
        {
            // Arange
            int courseId = 1;
            int moduleId = 1;
            LanguageName languageName = LanguageName.English;
            LanguageLevel languageLevel = LanguageLevel.Elementary;

            SetupMockServiceMethod(expectedStatusCode, methodName);

            List<Func<Task<IActionResult>>> methods = new List<Func<Task<IActionResult>>>
            {
                () => _controller.ViewCourse(courseId),
                () => _controller.CreateCourse(new LanguageCourse("Name", "description", languageName, languageLevel, "IconPath")),
                () => _controller.DeleteCourse(courseId),
                () => _controller.UpdateCourse(_updateCourseDto, courseId),
                () => _controller.AddModule(new CourseModule(), courseId),
                () => _controller.DeleteModule(courseId, moduleId),
                () => _controller.ViewCourses(_filterDto)
            };

            // Act
            IActionResult result = methodName switch
            {
                "GetCourseById" => await methods[0](),
                "CreateCourse" => await methods[1](),
                "DeleteCourse" => await methods[2](),
                "UpdateCourse" => await methods[3](),
                "AddModule" => await methods[4](),
                "DeleteModule" => await methods[5](),
                "GetFillterCourses" => await methods[6](),

                _ => throw new InvalidOperationException("Incorrect method")
            };

            // Assert
            switch (result)
            {
                case NotFoundObjectResult notFoundResult:
                    Assert.Equal(expectedStatusCode, notFoundResult.StatusCode);
                    break;

                case ObjectResult objectResult when objectResult.StatusCode == 404:
                    Assert.Equal(expectedStatusCode, objectResult.StatusCode);
                    break;

                case ObjectResult objectResult when objectResult.StatusCode == 500:
                    Assert.Equal(expectedStatusCode, objectResult.StatusCode);
                    break;

                case ObjectResult objectResult when objectResult.StatusCode == 200:
                    Assert.Equal(expectedStatusCode, objectResult.StatusCode);
                    break;
            }
        }
        private void SetupMockServiceMethod(int expectedStatusCode, string methodName, string message = "TestMessage")
        {
            LanguageName languageName = LanguageName.English;
            LanguageLevel languageLevel = LanguageLevel.Elementary;
            switch (methodName)
            {
                case "GetCourseById":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.GetCourseById(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(new LanguageCourse("Name", "description", languageName, languageLevel, "IconPath")));
                    }
                    else if (expectedStatusCode == 400)
                    {
                        _mockService.Setup(s => s.GetCourseById(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleBadRequest<LanguageCourse>(message));
                    }
                    else if (expectedStatusCode == 404)
                    {
                        _mockService.Setup(s => s.GetCourseById(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleNotFound<LanguageCourse>(message));
                    }
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.GetCourseById(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<LanguageCourse>(message));
                    }
                    break;

                case "CreateCourse":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.CreateCourse(It.IsAny<LanguageCourse>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(new LanguageCourse("Name", "description", languageName, languageLevel, "IconPath")));
                    }
                    else if (expectedStatusCode == 400)
                    {
                        _mockService.Setup(s => s.CreateCourse(It.IsAny<LanguageCourse>()))
                            .ReturnsAsync(BaseResponseHelper.HandleBadRequest<LanguageCourse>(message));
                    }
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.CreateCourse(It.IsAny<LanguageCourse>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<LanguageCourse>(message));
                    }
                    break;

                case "DeleteCourse":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.DeleteCourse(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(true));
                    }
                    else if (expectedStatusCode == 400)
                    {
                        _mockService.Setup(s => s.DeleteCourse(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleBadRequest<bool>(message));
                    }
                    else if (expectedStatusCode == 404)
                    {
                        _mockService.Setup(s => s.DeleteCourse(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleNotFound<bool>(message));
                    }
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.DeleteCourse(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<bool>(message));
                    }
                    break;

                case "UpdateCourse":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.UpdateCourse(It.IsAny<UpdateCourseDto>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(new LanguageCourse("Name", "description", languageName, languageLevel, "IconPath")));
                    }
                    else if (expectedStatusCode == 400)
                    {
                        _mockService.Setup(s => s.UpdateCourse(It.IsAny<UpdateCourseDto>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleBadRequest<LanguageCourse>(message));
                    }
                    else if (expectedStatusCode == 404)
                    {
                        _mockService.Setup(s => s.UpdateCourse(It.IsAny<UpdateCourseDto>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleNotFound<LanguageCourse>(message));
                    }
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.UpdateCourse(It.IsAny<UpdateCourseDto>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<LanguageCourse>(message));
                    }
                    break;

                case "AddModule":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.AddModule(It.IsAny<CourseModule>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(new LanguageCourse("Name", "description", languageName, languageLevel, "IconPath")));
                    }
                    else if (expectedStatusCode == 400)
                    {
                        _mockService.Setup(s => s.AddModule(It.IsAny<CourseModule>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleBadRequest<LanguageCourse>(message));
                    }             
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.AddModule(It.IsAny<CourseModule>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<LanguageCourse>(message));
                    }
                    break;

                case "DeleteModule":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.DeleteModule(It.IsAny<int>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(true));
                    }
                    else if (expectedStatusCode == 400)
                    {
                        _mockService.Setup(s => s.DeleteModule(It.IsAny<int>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleBadRequest<bool>(message));
                    }
                    else if (expectedStatusCode == 404)
                    {
                        _mockService.Setup(s => s.DeleteModule(It.IsAny<int>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleNotFound<bool>(message));
                    }
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.DeleteModule(It.IsAny<int>(), It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<bool>(message));
                    }
                    break;

                case "GetFillterCourses":

                    var coursesList = new List<LanguageCourse>
                    {
                        new LanguageCourse( "Name", "description", languageName, languageLevel, "IconPath"),
                        new LanguageCourse ("Name2", "description2", languageName, languageLevel, "IconPath2"),
                        // Добавьте больше курсов, если необходимо
                    };

                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.GetFillterCourses(It.IsAny<CourseFilterDto>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(new List<LanguageCourse>
                            {
                                new LanguageCourse( "Name", "description", languageName, languageLevel, "IconPath"),
                                new LanguageCourse ("Name2", "description2", languageName, languageLevel, "IconPath2"),
                            }.AsEnumerable()));
                    }
                    else if (expectedStatusCode == 400)
                    {
                        _mockService.Setup(s => s.GetFillterCourses(It.IsAny<CourseFilterDto>()))
                            .ReturnsAsync(BaseResponseHelper.HandleBadRequest<IEnumerable<LanguageCourse>>(message));
                    }
                    else if (expectedStatusCode == 404)
                    {
                        _mockService.Setup(s => s.GetFillterCourses(It.IsAny<CourseFilterDto>()))
                            .ReturnsAsync(BaseResponseHelper.HandleNotFound<IEnumerable<LanguageCourse>>(message));
                    }
                    else if (expectedStatusCode == 500)
                        _mockService.Setup(s => s.GetFillterCourses(It.IsAny<CourseFilterDto>()))
                                    .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<IEnumerable<LanguageCourse>>(message));
                    break;
            }
        }
    }
}
