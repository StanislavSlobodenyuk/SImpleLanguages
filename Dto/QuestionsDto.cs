
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Entity.Content.Question.Answer;
using Domain.Enum;

namespace Dto
{
    public class QuestionDto
    {
        public int UniqueId { get; set; }

        public string? QuestionText { get; set; }
        public QuestionType QType { get; set; }
        public AnswerType AType { get; set; }
        public IEnumerable<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();
        public IEnumerable<LessonQuestion> LessonQuestions { get; set; } = new List<LessonQuestion>();
        public string? ImagePath { get; set; }
        public string? AudioPath { get; set; }
        public string? Text { get; set; }
    }
}
