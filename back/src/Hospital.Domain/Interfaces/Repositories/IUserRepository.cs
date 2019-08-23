using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> List();
        Task<User> Create(User user);
        Task<User> FindById(int id);
        void Update(User user);
        void Remove(User user);
        Task<User> Authenticate(string email, string password);
    }
}
