using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [Route(template: "/api/v1/users/quizzes")]
    public class ApiQuizUserController : ControllerBase
    {
        private IQuizUserService _service;

        public ApiQuizUserController(IQuizUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route(template:"{id}")]
        public Quiz FindQuizById(int id)
        {
            var quiz = _service.FindQuizById(id);
          
            return _service.FindQuizById(id);
        }
        [HttpPost]
        [Route(template:"{quizId}/items/{itemId}/answers")]
        public ActionResult<object> SaveAnswer(int quizId, int itemId, AnswerDTO dto)
        {
            _service.SaveUserAnswerForQuiz(quizId, userId: 1, itemId, dto.Answer);
            return Created();
        }

        [HttpGet]
        [Route("{quizId}/answers")]
        public ActionResult<object> ReturnFeedback(int quizId)
        {
            int correct = _service.CountCorrectAnswersForQuizFilledByUser(quizId, 1);

            return new
            {
                CorrectAnswers = correct,
                QuizId = quizId,
                UserId = 1
            };
        }
    }
}
