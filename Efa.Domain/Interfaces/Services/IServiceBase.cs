using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Efa.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IEnumerable<TEntity> GetAll(int skip, int take);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);        
    }
}