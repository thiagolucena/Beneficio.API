using Beneficio.Domain.Entities;
using Beneficio.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public class AnexoBeneficioService : IAnexoBeneficioService
    {
        public readonly IAnexoBeneficioRepository _repository;

        public AnexoBeneficioService(IAnexoBeneficioRepository repository)
        {
            _repository = repository;
        }

        public void Add(AnexoBeneficio entity)
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

        public async Task<bool> SaveChangesAsync()
        {
            return await _repository.SaveChangesAsync();
        }

        public void Update(int id, AnexoBeneficio entity)
        {
            _repository.Update(id, entity);
        }

        public async Task<AnexoBeneficio> GetAsyncByBeneficioId(int Id)
        {
            return await _repository.GetAsyncByBeneficioId(Id);
        }

        public async Task<AnexoBeneficio> GetAsyncById(int Id)
        {
            return await _repository.GetAsyncById(Id);
        }

    }
}
