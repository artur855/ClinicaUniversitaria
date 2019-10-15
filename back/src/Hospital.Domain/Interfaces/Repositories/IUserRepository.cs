using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Authenticate(string email, string password);
    }
}
