using Beneficio.Infra.Data.Context;
using Beneficio.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
    {
        protected readonly BeneficioContext _beneficioContext;
        public BaseRepository(BeneficioContext beneficioContext)
        {
            _beneficioContext = beneficioContext;
            _beneficioContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        public void Add(T entity)
        {
            _beneficioContext.Set<T>().Add(entity);
            _beneficioContext.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _beneficioContext.SaveChangesAsync()) > 0;
        }
        public T FindById(object pk)
        {
            return _beneficioContext.Set<T>().Find(pk);
        }

        public void Update(object pk,T entity) 
        {
            T obj = FindById(pk);
            _beneficioContext.Entry(obj).CurrentValues.SetValues(entity);
            _beneficioContext.Entry(obj).State = EntityState.Modified;
            _beneficioContext.SaveChanges();
        }

        public void Delete(object pk) 
        {
            T obj = FindById(pk);
            _beneficioContext.Set<T>().Remove(obj);
            _beneficioContext.SaveChanges();
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
