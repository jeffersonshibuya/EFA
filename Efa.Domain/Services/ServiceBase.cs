using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Efa.Domain.Interfaces.Repository;
using Efa.Domain.Interfaces.Services;

namespace Efa.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class 
    {
         private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public virtual IEnumerable<TEntity> GetAll(int skip, int take)
        {
            return _repository.GetAll(skip, take);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }    
    }
}