using System;
using WpfApplication2.Connection;
using WPFAppPractice.repository.Interfaces;
using WPFAppPractice.repository.Repositories;

namespace WPFAppPractice.WpfApplication2.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ProductDBContext db;
        private ProductsRepository pRep;
        private CategoriesRepository cRep;

        public UnitOfWork(ProductDBContext db)
        {
            if (db == null)
            {
                throw new ArgumentNullException("DB context is missing!");
            }
            this.db = db;
        }
        public ICategoriesRepository Categories
        {
            get
            {
                if (cRep == null) { cRep = new CategoriesRepository(db); }
                return cRep;
            }
        }

        public IProductsRepository Products
        {
            get
            {
                if (pRep == null) { pRep = new ProductsRepository(db); }
                return pRep;
            }
        }

        public void Save()
        {
            db.SaveChanges();
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
        // ~UnitOfWork() {
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
