using Beneficio.Domain.Entities;
using Beneficio.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public class CategoriaService : ICategoriaService
    {
        public readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public void Add(Categoria entity)
        {
            _repository.Add(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public Categoria FindById(int id)
        {
            return  _repository.FindById(id);
        }

        public async Task<List<Categoria>> GetAllCategoriaAsync()
        {
            return await _repository.GetAllCategoriaAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _repository.SaveChangesAsync();
        }

        public void Update(int id, Categoria entity)
        {
            _repository.Update(id, entity);
        }
    }
}
