using Beneficio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public interface ICategoriaService
    {
        void Add(Categoria entity);
        void Update(int id, Categoria entity);
        void Delete(int id);
        Task<bool> SaveChangesAsync();
        void Dispose();
        Task<List<Categoria>> GetAllCategoriaAsync();
        Categoria FindById(int id);
    }
}
