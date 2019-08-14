using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IRespository<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Remove(int id);
        T selectById(int id);
        IEnumerable<T> selectAll();
    }
}
