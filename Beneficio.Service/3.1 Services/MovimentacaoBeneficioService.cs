using Beneficio.Domain.Entities;
using Beneficio.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public class MovimentacaoBeneficioService : IMovimentacaoBeneficioService
    {
        public readonly IMovimentacaoBeneficioRepository _repository;

        public MovimentacaoBeneficioService(IMovimentacaoBeneficioRepository repository)
        {
            _repository = repository;
        }

        public void Add(MovimentacaoBeneficio entity)
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

        public void Update(int id, MovimentacaoBeneficio entity)
        {
            _repository.Update(id, entity);
        }

        public async Task<MovimentacaoBeneficio> GetAsyncById(int Id)
        {
            return await _repository.GetAsyncById(Id);
        }
    }
}
