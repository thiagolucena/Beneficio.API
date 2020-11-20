using Beneficio.Domain.Entities;
using Beneficio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneficio.Infra.Data.Repository
{
    public class BeneficioServidorRepository : BaseRepository<BeneficioServidor>, IBeneficioServidorRepository
    {
        public BeneficioServidorRepository(BeneficioContext beneficioContext)
            : base(beneficioContext)
        {
            _beneficioContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<BeneficioServidor> GetAsyncById(int Id)
        {   
            IQueryable<BeneficioServidor> query = _beneficioContext.BeneficioServidores
                .Include(c => c.LstAnexos).ThenInclude(t => t.Categoria)
                .Include(c => c.Orgao)
                .Include(c => c.Servidor)
                .Include(c => c.Setor)
                .AsNoTrackingWithIdentityResolution()
                .AsNoTracking()
                .Where(c => c.Id == Id);
            

            return await query.FirstOrDefaultAsync();
        }

        public async Task<BeneficioServidor> GetAsyncByMatricula(string matricula)
        {
            IQueryable<BeneficioServidor> query = _beneficioContext.BeneficioServidores
                .Include(c => c.LstAnexos).ThenInclude(t => t.Categoria)
                .Include(c => c.LstMovimentacoesBeneficio).ThenInclude(t => t.SetorOrigem)
                .Include(c => c.LstMovimentacoesBeneficio).ThenInclude(t => t.SetorDestino)
                .Include(c => c.Orgao)
                .Include(c => c.Servidor)
                .Include(c => c.Setor)
                .AsNoTrackingWithIdentityResolution()
                .AsNoTracking()
                .Where(c => c.Servidor.Matricula == matricula);

            return await query.FirstOrDefaultAsync();
        }
        
    }
}
