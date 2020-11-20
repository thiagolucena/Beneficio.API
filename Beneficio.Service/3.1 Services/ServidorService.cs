using AutoMapper;
using Beneficio.Domain.Entities;
using Beneficio.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public class ServidorService : IServidorService
    {
        public readonly IServidorRepository _baseRepository;

        public ServidorService(IServidorRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Add(Servidor entity)
        {
            _baseRepository.Add(entity);
        }

        public Servidor FindById(int id)
        {
            return _baseRepository.FindById(id);
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _baseRepository.SaveChangesAsync();
        }

        public void Update(int id, Servidor entity)
        {
            _baseRepository.Update(id, entity);
        }

        public async Task<Servidor> GetAsyncByName(string name)
        {
            return await _baseRepository.GetAsyncByName(name);
        }

        public async Task<Servidor> GetAsyncByMatricula(string matricula)
        {
            return await _baseRepository.GetAsyncByMatricula(matricula);
        }
    }
}
