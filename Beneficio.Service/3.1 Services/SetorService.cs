using Beneficio.Domain.Entities;
using Beneficio.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public class SetorService : ISetorService
    {
        public readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }
        public void Add(Setor entity)
        {
            _setorRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _setorRepository.Delete(id);
        }

        public void Dispose()
        {
            _setorRepository.Dispose();
        }

        public async Task<List<Setor>> GetAllSetorAsync()
        {
            return await _setorRepository.GetAllSetorAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _setorRepository.SaveChangesAsync();
        }

        public void Update(int id, Setor entity)
        {
            _setorRepository.Update(id, entity);
        }
    }
}
