using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Energetic.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllNoTracking();

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        IQueryable<T> FilterNoTracking(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void DeleteAll(IEnumerable<T> items);
    }
}
