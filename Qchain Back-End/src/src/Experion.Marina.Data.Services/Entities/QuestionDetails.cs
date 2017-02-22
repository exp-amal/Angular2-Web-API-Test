using Experion.Marina.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Services.Entities
{
    public class QuestionDetails:IQuestionDetails
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public int AnswerCount { get; set; }
        public DateTime Date { get; set; }
        public List<string> Answers { get; set; }
        public long QuestionId { get; set; }
    }
}
