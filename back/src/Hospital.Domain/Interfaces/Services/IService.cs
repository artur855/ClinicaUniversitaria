using FluentValidation;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IService<T> where T : Entity
    {
        Task<T> SaveAsync<V>(T obj) where V : AbstractValidator<T>;
        Task<T> UpdateAsync<V>(T obj) where V : AbstractValidator<T>;
        Task<T> DeleteAsync(int id);
        Task<IEnumerable<T>> ListAsync();
        Task<T> FindByIdAsync(int id);
    }
}
