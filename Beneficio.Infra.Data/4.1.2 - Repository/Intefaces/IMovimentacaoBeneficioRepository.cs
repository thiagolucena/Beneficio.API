using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Infra.Data.Repository
{
    public interface IMovimentacaoBeneficioRepository : IBaseRepository<MovimentacaoBeneficio>
    {
        Task<MovimentacaoBeneficio> GetAsyncById(int Id);

    }
}
