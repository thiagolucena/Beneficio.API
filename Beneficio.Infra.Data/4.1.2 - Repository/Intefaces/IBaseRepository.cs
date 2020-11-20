using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Infra.Data.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(object pk,T entity);
        void Delete(object pk);
        Task<bool> SaveChangesAsync();
        T FindById(object pk);
        void Dispose();

    }
}
