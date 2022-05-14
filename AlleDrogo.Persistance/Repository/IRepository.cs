using AlleDrogo.Domain.Entities.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AlleDrogo.Persistance.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
