using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Contracts.Entities
{
    public interface IQuestionDetails
    {
        string Title { get; set; }
        string Description { get; set; }
        string Owner { get; set; }
        int AnswerCount { get; set; }
        DateTime Date { get; set; }
        List<string> Answers { get; set; }
        long QuestionId { get; set; }
    }
}
