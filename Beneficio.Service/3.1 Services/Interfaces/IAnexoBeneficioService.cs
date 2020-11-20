using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public interface IAnexoBeneficioService
    {
        void Add(AnexoBeneficio entity);
        void Update(int id, AnexoBeneficio entity);
        void Delete(int id);
        Task<bool> SaveChangesAsync();
        void Dispose();
        Task<AnexoBeneficio> GetAsyncByBeneficioId(int Id);
        Task<AnexoBeneficio> GetAsyncById(int Id);
    }
}
