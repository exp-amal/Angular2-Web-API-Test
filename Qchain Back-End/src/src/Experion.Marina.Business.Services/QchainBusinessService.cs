using Autofac;
using Experion.Marina.Business.Services.Contracts;
using Experion.Marina.Core;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Dto;
using System;
using System.Collections.Generic;

namespace Experion.Marina.Business.Services
{
    public class QchainBusinessService : BusinessService, IQchainBusinessService
    {
        private readonly IComponentContext _iocContext;

        public QchainBusinessService(IComponentContext iocContext)
        {
            _iocContext = iocContext;
        }

        //User Registration
        public void AddUser(UserDto userDetails)
        {
            var QchainDataService = _iocContext.Resolve<IQchainDataService>();
            var users = _iocContext.Resolve<IUser>();
            users.FirstName = userDetails.FirstName;
            users.LastName = userDetails.LastName;
            users.Dob = userDetails.Dob;
            users.Email = userDetails.Email;
            users.UserName = userDetails.UserName;
            users.Password = userDetails.Password;
            QchainDataService.AddUser(users);
        }

        //User Login
        public int UserLogin(LoginDto loginDetails)
        {
            var qchainDataService = _iocContext.Resolve<IQchainDataService>();
            var Loginuser = _iocContext.Resolve<ILogin>();
            Loginuser.UserName = loginDetails.UserName;
            Loginuser.PassWord = loginDetails.PassWord;
            int status = qchainDataService.UserLogin(Loginuser);
            return status;

        }

        //Submit question
        public void SubmitQuestion(QuestionDto questionDetail)
        {
            var qchainDataService = _iocContext.Resolve<IQchainDataService>();
            var question = _iocContext.Resolve<IQuestion>();
            question.Title = questionDetail.Title;
            question.Description = questionDetail.Description;
            question.Owner = questionDetail.Owner;
            question.Date = DateTime.Now;
            qchainDataService.SubmitQuestion(question);
        }

        //Get Questions from the database
        public List<QuestionsDto> GetQuestions()
        {
            var qchainDataService = _iocContext.Resolve<IQchainDataService>();
            var result = qchainDataService.GetQuestion();
            List<QuestionsDto> listOfQuestions = new List<QuestionsDto>();
            foreach (var questions in result)
            {
                listOfQuestions.Add(new QuestionsDto
                {
                    id = questions.Id,
                    Title = questions.Title,
                    Description = questions.Description,
                    Date = questions.Date,
                    Owner = questions.Owner,
                    count = questions.count

                });
            }
            return listOfQuestions;
        }

        //Submit Answer
        public void SubmitAnswer(AnswerDto Answer)
        {
            var qchainDataService = _iocContext.Resolve<IQchainDataService>();
            var answer = _iocContext.Resolve<IAnswer>();
            answer.Answers = Answer.Answer;
            answer.QuestionId = Answer.id;

            qchainDataService.SubmitAnswer(answer);

        }

        //Getting question details
        public QuestionDetailDto GetQuestionDetail(int id)
        {
            var qchainDataService = _iocContext.Resolve<IQchainDataService>();
            var result = qchainDataService.GetQuestionDetails(id);
            var questionDetails = new QuestionDetailDto();
            questionDetails.Title = result.Title;
            questionDetails.Description = result.Description;
            questionDetails.Date = result.Date;
            questionDetails.Answers = result.Answers;
            questionDetails.Owner = result.Owner;
            questionDetails.AnswerCount = result.AnswerCount;
            questionDetails.QuestionId = result.QuestionId;
            return questionDetails;

        }

    }
}
