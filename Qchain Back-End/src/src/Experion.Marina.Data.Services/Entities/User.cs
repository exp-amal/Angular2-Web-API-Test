using Experion.Marina.Data.Contracts;
using System;

namespace Experion.Marina.Data.Services
{
    public class User : IUser, IEntity<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}