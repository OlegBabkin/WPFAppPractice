using System;
using System.Linq;
using System.Linq.Expressions;

namespace WPFAppPractice.repository.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAllEntries();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        //void Commit();
    }
}
