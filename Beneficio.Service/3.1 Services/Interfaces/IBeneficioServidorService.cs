using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public interface IBeneficioServidorService
    {
        void Add(BeneficioServidor entity);
        void Update(int id, BeneficioServidor entity);
        void Delete(int id);
        Task<bool> SaveChangesAsync();
        void Dispose();
        Task<BeneficioServidor> GetAsyncById(int Id);
        Task<BeneficioServidor> GetAsyncByMatricula(string matricula);

    }
}
