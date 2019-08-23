using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hospital.Domain.DTO;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> FindByIdAsync(int id);
        Task<IEnumerable<User>> ListAsync();
        Task<User> SaveAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
