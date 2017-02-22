using Experion.Marina.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Services.Entities
{
    public class Question:IQuestion,IEntity<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime Date { get; set; }
        public List<Answer> ListofAnswers { get; set; }
    }
}
