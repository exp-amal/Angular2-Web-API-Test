using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Contracts.Entities
{
    public interface ILogin
    {
        
        string UserName { get; set; }
        string PassWord { get; set; }
    }

}
