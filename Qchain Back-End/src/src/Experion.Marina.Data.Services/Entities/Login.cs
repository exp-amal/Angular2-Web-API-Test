using Experion.Marina.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.Marina.Data.Services.Entities
{
    public class Login:ILogin
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
