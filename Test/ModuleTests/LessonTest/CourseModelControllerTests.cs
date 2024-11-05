using Application.Controllers;
using Common.Response;
using Domain.Entity.Content.Lessons;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Interfaces;
using Xunit;

namespace Test.ModuleTests.LessonTest
{
    public class CourseModelControllerTests
    {
        private readonly CourseModuleController _controller;
        private readonly Mock<ICourseModuleService> _mockService;
        private readonly UpdateCourseModuleDto _updateDto;

        public CourseModelControllerTests() 
        {
            _mockService = new Mock<ICourseModuleService>();
            _controller = new CourseModuleController(_mockService.Object);
            _updateDto = new UpdateCourseModuleDto();
        }

        [Theory]
        [InlineData(200, "GetModule")]
        [InlineData(404, "GetModule")]
        [InlineData(500, "GetModule")]
        [InlineData(200, "UpdateModule")]
        [InlineData(400, "UpdateModule")]
        [InlineData(404, "UpdateModule")]
        [InlineData(500, "UpdateModule")]
        [InlineData(200, "ChangeAvailableModule")]
        [InlineData(404, "ChangeAvailableModule")]
        [InlineData(500, "ChangeAvailableModule")]
        //[InlineData(200, "AddLesson")]
        //[InlineData(400, "AddLesson")]
        //[InlineData(404, "AddLesson")]
        //[InlineData(500, "AddLesson")]
        [InlineData(200, "DeleteLesson")]
        [InlineData(404, "DeleteLesson")]
        [InlineData(500, "DeleteLesson")]
        public async Task Test_BadResponse_For_DifferentMethods(int expectedStatusCode, string methodName)
        {
            // Arrange
            int moduleId =  1;
            //int lessonid = 1;

            SetupMockServiceMethod(expectedStatusCode, methodName);

            List<Func<Task<IActionResult>>> method = new List<Func<Task<IActionResult>>>() 
            {
                () => _controller.GetModule(moduleId),
                () => _controller.UpdateModule(_updateDto, moduleId),
                () => _controller.ChangeAccess(moduleId),
                () => _controller.AddLesson(new Lesson("lesson1", true, 2), moduleId),
                //() => _controller.DeleteLesson(moduleId, lessonid),
            };

            // Act

            IActionResult result = methodName switch
            {
                "GetModule" => await method[0](),
                "UpdateModule" => await method[1](),
                "ChangeAvailableModule" => await method[2](),
                "AddLesson" => await method[3](),
                "DeleteLesson" => await method[4](),

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
            CourseModule courseModule = new CourseModule("module1", true, "iconPath");
            Lesson lesson = new Lesson("lesson1", true, 2);
            switch (methodName)
            {
                case "GetModule":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.GetModule(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(courseModule));
                    }
                    else if (expectedStatusCode == 404)
                    {
                        _mockService.Setup(s => s.GetModule(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleNotFound<CourseModule>(message));
                    }
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.GetModule(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<CourseModule>(message));
                    }
                    break;

                case "UpdateModule":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.UpdateModule(_updateDto, It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(courseModule));
                    }
                    else if (expectedStatusCode == 404)
                    {
                        _mockService.Setup(s => s.UpdateModule(_updateDto, It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleNotFound<CourseModule>(message));
                    }
                    else if (expectedStatusCode == 400)
                    {
                        _mockService.Setup(s => s.UpdateModule(_updateDto, It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleBadRequest<CourseModule>(message));
                    }
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.UpdateModule(_updateDto, It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<CourseModule>(message));
                    }
                    break;

                case "ChangeAvailableModule":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.ChangeAvailableModule(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(courseModule));
                    }
                    else if (expectedStatusCode == 404)
                    {
                        _mockService.Setup(s => s.ChangeAvailableModule(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleNotFound<CourseModule>(message));
                    }
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.ChangeAvailableModule(It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<CourseModule>(message));
                    }
                    break;

                case "AddLesson":
                    if (expectedStatusCode == 200)
                    {
                        _mockService.Setup(s => s.AddLesson(lesson, It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(courseModule));
                    }
                    else if (expectedStatusCode == 404)
                    {
                        _mockService.Setup(s => s.AddLesson(lesson, It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleNotFound<CourseModule>(message));
                    }
                    else if (expectedStatusCode == 400)
                    {
                        _mockService.Setup(s => s.AddLesson(lesson, It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleBadRequest<CourseModule>(message));
                    }
                    else if (expectedStatusCode == 500)
                    {
                        _mockService.Setup(s => s.AddLesson(lesson, It.IsAny<int>()))
                            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<CourseModule>(message));
                    }
                    break;

                //case "DeleteLesson":
                //    if (expectedStatusCode == 200)
                //    {
                //        _mockService.Setup(s => s.DeleteLesson(It.IsAny<int>(), It.IsAny<int>()))
                //            .ReturnsAsync(BaseResponseHelper.HandleSuccessfulRequest(true));
                //    }
                //    else if (expectedStatusCode == 404)
                //    {
                //        _mockService.Setup(s => s.DeleteLesson(It.IsAny<int>(), It.IsAny<int>()))
                //            .ReturnsAsync(BaseResponseHelper.HandleNotFound<bool>(message));
                //    }
                //    else if (expectedStatusCode == 500)
                //    {
                //        _mockService.Setup(s => s.DeleteLesson(It.IsAny<int>(), It.IsAny<int>()))
                //            .ReturnsAsync(BaseResponseHelper.HandleInternalServerError<bool>(message));
                //    }
                //    break;
            }
        }
    }
}
