using Beneficio.Domain.Entities;
using Beneficio.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public class BeneficioServidorService : IBeneficioServidorService
    {
        public readonly IBeneficioServidorRepository _beneficioServidorRepository;

        public BeneficioServidorService(IBeneficioServidorRepository beneficioServidorRepository)
        {
            _beneficioServidorRepository = beneficioServidorRepository;
        }

        public void Add(BeneficioServidor entity)
        {
            _beneficioServidorRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _beneficioServidorRepository.Delete(id);
        }

        public void Dispose()
        {
            _beneficioServidorRepository.Dispose();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _beneficioServidorRepository.SaveChangesAsync();
        }

        public void Update(int id, BeneficioServidor entity)
        {
            _beneficioServidorRepository.Update(id, entity);
        }

        public async Task<BeneficioServidor> GetAsyncById(int Id)
        {
            return await _beneficioServidorRepository.GetAsyncById(Id);
        }

        public async Task<BeneficioServidor> GetAsyncByMatricula(string matricula)
        {
            return await _beneficioServidorRepository.GetAsyncByMatricula(matricula);
        }
    }
}
