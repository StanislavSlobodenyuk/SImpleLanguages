using Domain.Entity.Base;
using Domain.Entity.Content.Image;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question.Answer;
using Domain.Enum;

namespace Domain.Entity.Content.Question
{
    public abstract class BaseQuestion : BaseEntity
    {
        public string? QuestionText { get; set; }
        public QuestionType QType { get; set; }
        public AnswerType AType { get; set; }

        public ICollection<AnswerOption> AnswerOptions { get; private set; } = new List<AnswerOption>();
        public ICollection<RightAnswer> RightAnswers { get; private set; } = new List<RightAnswer>();
        public ICollection<LessonQuestion> LessonQuestions { get; private set; } = new List<LessonQuestion>();

        protected BaseQuestion() { } 

        protected BaseQuestion(string questionText, QuestionType QuestionType, AnswerType answerType)
        {
            QuestionText = questionText;
            QType = QuestionType;
            AType = answerType;
        }
    }
}

