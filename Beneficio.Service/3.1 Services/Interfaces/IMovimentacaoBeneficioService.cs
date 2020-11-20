using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public interface IMovimentacaoBeneficioService
    {
        void Add(MovimentacaoBeneficio entity);
        void Update(int id, MovimentacaoBeneficio entity);
        void Delete(int id);
        Task<bool> SaveChangesAsync();
        void Dispose();
        Task<MovimentacaoBeneficio> GetAsyncById(int Id);
    }
}
