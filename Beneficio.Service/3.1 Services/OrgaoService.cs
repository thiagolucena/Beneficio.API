using Beneficio.Domain.Entities;
using Beneficio.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Service.Services
{
    public class OrgaoService : IOrgaoService
    {
        public readonly IOrgaoRepository _orgaoRepository;

        public OrgaoService(IOrgaoRepository orgaoRepository)
        {
            _orgaoRepository = orgaoRepository;
        }
        public void Add(Orgao entity)
        {
            _orgaoRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _orgaoRepository.Delete(id);
        }

        public void Dispose()
        {
            _orgaoRepository.Dispose();
        }

        public async Task<List<Orgao>> GetAllOrgaoAsync()
        {
            return await _orgaoRepository.GetAllOrgaoAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _orgaoRepository.SaveChangesAsync();
        }

        public void Update(int id, Orgao entity)
        {
            _orgaoRepository.Update(id, entity);
        }
    }
}
