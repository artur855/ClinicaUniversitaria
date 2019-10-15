using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task InsertAsync(T obj);
        T Update(T obj);
        Task<T> RemoveAsync(int id);
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate); 
    }
}
