using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hospital.Infra.Data.Context;
using Hospital.Domain.Interfaces.Repositories;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hospital.Infra.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly HospitalContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(HospitalContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task InsertAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task<T> RemoveAsync(int id)
        {
            T entity = await this.FindByIdAsync(id);
            if (entity != null)
                DbSet.Remove(entity);

            return entity;
        }

        public virtual T Update(T entity)
        {
            DbSet.Update(entity);

            return entity;
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

    }
}
