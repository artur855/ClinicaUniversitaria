using FluentValidation;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public void Delete(Guid id)
        {
            repository.Remove(id);
        }

        public T Get(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("The Id can't be zero");

            return repository.selectById(id);

        }

        public IList<T> Get()
        {
            return repository.selectAll();
        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("object is null");

            validator.ValidateAndThrow(obj);
        }
    }
}
