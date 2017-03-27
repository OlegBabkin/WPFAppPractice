using System;
using System.Linq;
using WPFAppPractice.repository.Repositories;
using WPFAppPractice.domain;
using System.Linq.Expressions;
using WpfApplication2.Connection;

namespace WPFAppPractice.WpfApplication2.Infrastructure
{
    public class ProductsRepository : IProductsRepository
    {
        ProductDBContext db;

        //public ProductsRepository()
        //{
        //    this.db = new ProductDBEntities();
        //}

        public ProductsRepository(ProductDBContext db)
        {
            this.db = db;
        }

        public Product GetByID(int key)
        {
            return db.Products.FirstOrDefault(p => p.Id == key);
        }

        //public void Commit()
        //{
        //    db.SaveChanges();
        //}

        public void Delete(Product entity)
        {
            db.Products.Remove(entity);
        }

        public IQueryable<Product> FindBy(Expression<Func<Product, bool>> predicate)
        {
            return GetAllEntries().Where(predicate);
        }

        public IQueryable<Product> GetAllEntries()
        {
            return db.Products.AsQueryable<Product>();
        }

        public void Insert(Product entity)
        {
            db.Products.Add(entity);
        }

        public void Update(Product entity)
        {
            var oldEntry = db.Products.Find(entity.Id);
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
        // ~ProductsRepository() {
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
