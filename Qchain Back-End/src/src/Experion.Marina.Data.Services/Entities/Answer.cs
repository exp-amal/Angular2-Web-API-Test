using Experion.Marina.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Services.Entities
{
   public  class Answer: IAnswer, IEntity<long>
    {
        public long Id { get; set; }
        public string Answers { get; set; }
        public long QuestionId { get; set; }
        public Question Question { get; set; }
        public DateTime AnswerDate { get; set; }
    }
}
