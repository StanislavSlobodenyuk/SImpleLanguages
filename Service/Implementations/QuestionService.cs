
using Common.Response;
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Domain.Entity.Content.Question;
using Domain.Entity.Content.Question.Answer;
using Domain.Enum;
using Dto;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILessonRepository _lessonRepository;

        public QuestionService(IQuestionRepository questionRepository, ILessonRepository lessonRepository)
        {
            _questionRepository = questionRepository;
            _lessonRepository = lessonRepository;
        }

        public async Task<BaseResponse<List<QuestionDto>>> GetQuestions(int lessonId)
        {
            if (lessonId <= 0)
                return BaseResponseHelper.HandleBadRequest<List<QuestionDto>>("Invalid parameter lessonId <= 0");

            try
            {
                var lesson = await _lessonRepository.GetById(lessonId);

                if (lesson == null)
                    return BaseResponseHelper.HandleNotFound<List<QuestionDto>>($"Lesson with id {lessonId} not found");

                var questions = await _questionRepository.GetQuestions(lessonId);

                var questionsDtos = questions.Select((question, index) =>
                {
                    var baseQuestion = question as BaseQuestion;

                    return new QuestionDto
                    {
                        UniqueId = index + 1,
                        QuestionText = baseQuestion?.QuestionText,
                        QType = baseQuestion?.QType ?? QuestionType.None,
                        AType = baseQuestion?.AType ?? AnswerType.None,
                        AnswerOptions = baseQuestion?.AnswerOptions ?? new List<AnswerOption>(),
                        LessonQuestions = baseQuestion?.LessonQuestions ?? new List<LessonQuestion>(),
                        ImagePath = question is ImageQuestion iq ? iq.ImagePath : null,
                        AudioPath = question is AudioQuestion aq ? aq.AudioPath : null,
                        Text = question is TextQuestion tq ? tq.Text : null
                    };
                }).ToList();

                return BaseResponseHelper.HandleSuccessfulRequest(questionsDtos);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<List<QuestionDto>>("Server internal error");
            }
        }
    }
}
