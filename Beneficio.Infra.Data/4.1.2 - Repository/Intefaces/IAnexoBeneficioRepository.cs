using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Infra.Data.Repository
{
    public interface IAnexoBeneficioRepository : IBaseRepository<AnexoBeneficio>
    {
        Task<AnexoBeneficio> GetAsyncByBeneficioId(int Id);
        Task<AnexoBeneficio> GetAsyncById(int Id);

    }
}
