using Experion.Marina.Dto;
using System.Collections.Generic;

namespace Experion.Marina.Business.Services.Contracts
{
    public interface IQchainBusinessService
    {
        void AddUser(UserDto userDetails);
        int UserLogin(LoginDto LoginDetails);
        void SubmitQuestion(QuestionDto questionDetails);
        List<QuestionsDto> GetQuestions();
        void SubmitAnswer(AnswerDto Answer);
        QuestionDetailDto GetQuestionDetail(int id);


    }
}