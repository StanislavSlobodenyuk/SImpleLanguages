
using Domain.Enum;

namespace Dto
{
    public class CourseFilterDto
    {
        public string? SearchTitle { get; set; } = String.Empty;
        public string? Language { get; set; } = "All";
        public string? Level { get; set; } = "All";
        public string? LessonCount { get; set; } = "All";
        public string? Cost { get; set; } = "All";  
        public bool InDevelopment { get; set; } = false;
    }
}
