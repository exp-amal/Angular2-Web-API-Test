using Autofac;
using Experion.Marina.Data.Contracts;
using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Data.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Experion.Marina.Data.Services.Services
{
    public class QchainDataService : DataService<MarinaContext>, IQchainDataService
    {
        private IRepository<User, long> QchainRepository => DataContext.GetRepository<User, long>();
        private IRepository<Question, long> QuestionRepository => DataContext.GetRepository<Question, long>();
        private IRepository<Answer, long> AnswerRepository => DataContext.GetRepository<Answer, long>();

        public QchainDataService(IComponentContext iocContext, IRepositoryContext context)
            : base(iocContext, context)
        {
        }

        //User registration
        public void AddUser(IUser userDetails)
        {
            var users = new User
            {
                FirstName = userDetails.FirstName,
                LastName = userDetails.LastName,
                Dob = userDetails.Dob,
                Email = userDetails.Email,
                UserName = userDetails.UserName,
                Password = userDetails.Password
            };
            QchainRepository.Add(users);
            Save();
        }

        //User login
        public int UserLogin(ILogin loginDetails)
        {
            var param = new Specification<User>(x => (x.UserName == loginDetails.UserName && x.Password == loginDetails.PassWord));
            List<User> user = QchainRepository.GetBySpecification(param);
            var flag = 1;
            if (user.Count == 0)
            {
                flag = 0;
                return flag;
            }
            return flag;
        }

        //Submit question to the database
        public void SubmitQuestion(IQuestion questionDetail)
        {
            var question = new Question
            {
                Title = questionDetail.Title,
                Description = questionDetail.Description,
                Date = questionDetail.Date,
                Owner = questionDetail.Owner

            };
            QuestionRepository.Add(question);
            Save();
        }

        //getting questions from database
        public List<IQuestions> GetQuestion()
        {
            var result = QuestionRepository.GetAll();
            List<IQuestions> questions = new List<IQuestions>();
            List<IQuestions> unansweredQuestions = new List<IQuestions>();
            List<IQuestions> sortedList = new List<IQuestions>();
            //get count of answers for each question and sorting questions based on answer count
            foreach (var question in result)
            {
                var param = new Specification<Answer>(x => (x.QuestionId == question.Id));
                List<Answer> Answers = AnswerRepository.GetBySpecification(param);
                questions.Add(new Questions
                {
                    Id = question.Id,
                    Title = question.Title,
                    Description = question.Description,
                    Owner = question.Owner,
                    Date = question.Date,
                    count = Answers.Count
                }
                    );
            }
            List<IQuestions> sortedQuestions = questions.OrderBy(o => o.count).ToList();
            //sorting unanswered question based on time
            foreach (var question in sortedQuestions)
            {
                if (question.count == 0)
                {
                    unansweredQuestions.Add(new Questions
                    {
                        Id = question.Id,
                        Title = question.Title,
                        Description = question.Description,
                        Owner = question.Owner,
                        Date = question.Date,
                        count = question.count
                    });
                }
            }
            List<IQuestions> sortedUnansweredQuestions = unansweredQuestions.OrderByDescending(o => o.Date).ToList();
            sortedQuestions.RemoveAll(t => t.count == 0);
            //creating sorted answers based in their count and unanswerd questions based on date and time
            foreach (var question in sortedUnansweredQuestions)
            {
                sortedList.Add(new Questions
                {
                    Id = question.Id,
                    Title = question.Title,
                    Description = question.Description,
                    Owner = question.Owner,
                    Date = question.Date,
                    count = question.count
                });
            }

            foreach (var question in sortedQuestions)
            {
                sortedList.Add(new Questions
                {
                    Id = question.Id,
                    Title = question.Title,
                    Description = question.Description,
                    Owner = question.Owner,
                    Date = question.Date,
                    count = question.count
                });
            }
            return sortedList;
        }

        //Submit Answer
        public void SubmitAnswer(IAnswer Answer)
        {
            var answer = new Answer
            {
                QuestionId = Answer.QuestionId,
                Answers = Answer.Answers,
                AnswerDate = DateTime.Now
            };
            AnswerRepository.Add(answer);
            Save();
        }

        //Get question details
        public IQuestionDetails GetQuestionDetails(int id)
        {
            var details = QuestionRepository.GetById(id);
            var param = new Specification<Answer>(x => (x.QuestionId == details.Id));
            List<Answer> answerDetail = AnswerRepository.GetBySpecification(param);
            int count = details.ListofAnswers == null ? 0 : details.ListofAnswers.Count;

            List<Answer> sortedAnswerDetail = answerDetail.OrderByDescending(o => o.AnswerDate).ToList();
            List<string> answers = new List<string>();
            foreach (var answer in sortedAnswerDetail)
            {
                answers.Add(answer.Answers);
            }
            if (answers.Count == 0)
            {
                answers.Add("No Answer found");
                count = 0;
            }
            var questionDetails = new QuestionDetails
            {
                Title = details.Title,
                Description = details.Description,
                AnswerCount = count,
                Date = details.Date,
                Owner = details.Owner,
                Answers = answers,
                QuestionId = details.Id
            };
            return questionDetails;
        }
    }
}
