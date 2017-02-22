using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace Experion.Marina.Web.Api.Controllers
{
    public class QchainController : ApiController
    {
        private readonly IComponentContext _iocContext;

        public QchainController(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        /// <summary>
        /// Gets the sample.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>

        //User Registration
        [HttpPost]
        [Route("Registration")]
        public IHttpActionResult AddUser(UserDto userDetails)
        {
            var QchainService = _iocContext.Resolve<IQchainBusinessService>();
            QchainService.AddUser(userDetails);
            return Ok();
        }

        //user login
        [HttpPost]
        [Route("Login")]
        public int UserLogin(LoginDto loginDetails)
        {
            var qchainService = _iocContext.Resolve<IQchainBusinessService>();
            int status = qchainService.UserLogin(loginDetails);
            return status;
        }

        //submit question
        [HttpPost]
        [Route("SubmitQuestion")]
        public IHttpActionResult SubmitQuestion(QuestionDto questionDetail)
        {
            var qchainService = _iocContext.Resolve<IQchainBusinessService>();
            qchainService.SubmitQuestion(questionDetail);
            return Ok();
        }

        //Get questions from the Database
        [HttpGet]
        [Route("GetQuestions")]
        public List<QuestionsDto> GetQuestions()
        {
            var qchainService = _iocContext.Resolve<IQchainBusinessService>();
            List<QuestionsDto> questions = qchainService.GetQuestions();
            return questions;
        }

        //Submit Answer
        [HttpPost]
        [Route("SubmitAnswer")]
        public IHttpActionResult SubmitAnswer(AnswerDto answer)
        {
            var qchainService = _iocContext.Resolve<IQchainBusinessService>();
            qchainService.SubmitAnswer(answer);
            return Ok();
        }

        //Get question details
        [HttpGet]
        [Route("GetQuestionDetails/{id}")]
        public QuestionDetailDto GetQuestionDetails(int id)
        {
            var qchainService = _iocContext.Resolve<IQchainBusinessService>();
            var details = qchainService.GetQuestionDetail(id);
            return details;
        }



    }
}

