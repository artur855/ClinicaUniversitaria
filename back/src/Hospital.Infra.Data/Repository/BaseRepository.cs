using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Infra.Data.Repository
{
    public class BaseRepository<T> : IRespository<T> where T : BaseEntity
    {
        protected readonly HospitalContext Context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository()
        {
            Context = new HospitalContext();
            DbSet = Context.Set<T>();
        }

        public virtual void Insert(T obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual IList<T> selectAll()
        {
            return DbSet.ToList();
        }

        public virtual T selectById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(T obj)
        {
            DbSet.Update(obj);
        }
    }
}
