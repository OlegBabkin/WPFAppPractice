using System;
using System.Linq;
using WPFAppPractice.repository.Repositories;
using WPFAppPractice.domain;
using System.Linq.Expressions;
using WpfApplication2.Connection;

namespace WPFAppPractice.WpfApplication2.Infrastructure
{
    public class CategoriesRepository : ICategoriesRepository
    {
        ProductDBContext db;

        //public CategoriesRepository()
        //{
        //    db = new ProductDBEntities();
        //}

        public CategoriesRepository(ProductDBContext db)
        {
            this.db = db;
        }

        //public void Commit()
        //{
        //    db.SaveChanges();
        //}

        public void Delete(Category entity)
        {
            db.Categories.Remove(entity);
        }

        public IQueryable<Category> FindBy(Expression<Func<Category, bool>> predicate)
        {
            return GetAllEntries().Where(predicate);
        }

        public IQueryable<Category> GetAllEntries()
        {
            return db.Categories.AsQueryable<Category>();
        }

        public Category GetByID(int key)
        {
            return db.Categories.FirstOrDefault(p => p.Id == key);
        }

        public void Insert(Category entity)
        {
            db.Categories.Add(entity);
        }

        public void Update(Category entity)
        {
            var oldEntry = db.Categories.Find(entity.Id);
            db.Entry(oldEntry).CurrentValues.SetValues(entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (db != null)
                    {
                        db.Dispose();
                        db = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CategoriesRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
