using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Infra.Data.Repository
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Task<List<Categoria>> GetAllCategoriaAsync();
    }
}
