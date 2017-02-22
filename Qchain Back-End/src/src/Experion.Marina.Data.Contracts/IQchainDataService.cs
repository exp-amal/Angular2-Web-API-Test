using Experion.Marina.Data.Contracts.Entities;
using Experion.Marina.Dto;
using System.Collections;
using System.Collections.Generic;

namespace Experion.Marina.Data.Contracts
{
    public interface IQchainDataService
    {
        void AddUser(IUser userDetails);
        int UserLogin(ILogin loginDetails);
        void SubmitQuestion(IQuestion questionDetail);
        List<IQuestions> GetQuestion();
        void SubmitAnswer(IAnswer Answer);
        IQuestionDetails GetQuestionDetails(int id);


    }
}
