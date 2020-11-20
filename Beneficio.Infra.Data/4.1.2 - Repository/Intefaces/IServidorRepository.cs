using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Infra.Data.Repository
{
    public interface IServidorRepository : IBaseRepository<Servidor>
    {
        Task<Servidor> GetAsyncByName(string name);
        Task<Servidor> GetAsyncByMatricula(string matricula);
    }
}
