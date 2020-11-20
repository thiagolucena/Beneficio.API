using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Infra.Data.Repository
{
    public interface IBeneficioServidorRepository : IBaseRepository<BeneficioServidor>
    {
        Task<BeneficioServidor> GetAsyncById(int Id);
        Task<BeneficioServidor> GetAsyncByMatricula(string matricula);
    }
}
