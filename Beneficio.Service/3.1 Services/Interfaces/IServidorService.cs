using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public interface IServidorService
    {
        void Add(Servidor entity);
        Servidor FindById(int id);
        void Update(int id, Servidor entity);
        void Delete(int id);
        Task<bool> SaveChangesAsync();
        void Dispose();
        Task<Servidor> GetAsyncByName(string name);
        Task<Servidor> GetAsyncByMatricula(string matricula);

    }
}
