using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Interfaces
{
    public interface IRespository<T> where T :BaseEntity
    {
        void Insert(T obj);
        void Update(T obj);
        void Remove(Guid id);
        T selectById(Guid id);
        IList<T> selectAll();
    }
}
