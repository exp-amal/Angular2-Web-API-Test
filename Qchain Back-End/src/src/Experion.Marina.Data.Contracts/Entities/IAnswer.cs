using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Contracts.Entities
{
    public interface IAnswer
    {
        long Id { get; set; }
        string Answers { get; set; }
        long QuestionId { get; set; }
        
    }
}
