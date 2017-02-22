using System;

namespace Experion.Marina.Data.Contracts
{
    public interface IUser
    {
        long Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime Dob{ get; set; }
        string Email{ get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
