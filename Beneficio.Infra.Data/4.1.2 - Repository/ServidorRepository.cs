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
    public class ServidorRepository : BaseRepository<Servidor>, IServidorRepository
    {
        public ServidorRepository(BeneficioContext beneficioContext)
            : base(beneficioContext)
        {
            _beneficioContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Servidor> GetAsyncByName(string name)
        {
            IQueryable<Servidor> query = _beneficioContext.Servidores
                .AsNoTrackingWithIdentityResolution()
                .AsNoTracking()
                .Where(c => c.Nome == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Servidor> GetAsyncByMatricula(string matricula)
        {
            IQueryable<Servidor> query = _beneficioContext.Servidores
                .AsNoTrackingWithIdentityResolution()
                .AsNoTracking()
                .Where(c => c.Matricula == matricula);

            return await query.FirstOrDefaultAsync();
        }

    }
}
