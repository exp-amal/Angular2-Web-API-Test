using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Contracts.Entities
{
   public  interface IQuestions
    {
        long Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Owner { get; set; }
        DateTime Date { get; set; }
        int count { get; set; }
    }
}
