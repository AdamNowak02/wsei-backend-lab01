using BackendLab01;
using Microsoft.AspNetCore.Mvc;

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
            return _service.FindQuizById(id);
        }
    }
}
