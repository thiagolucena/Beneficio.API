using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public interface ISetorService
    {
        void Add(Setor entity);
        void Update(int id, Setor entity);
        void Delete(int id);
        Task<bool> SaveChangesAsync();
        void Dispose();
        Task<List<Setor>> GetAllSetorAsync();
    }
}
