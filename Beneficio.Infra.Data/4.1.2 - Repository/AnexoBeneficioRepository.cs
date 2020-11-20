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
    public class AnexoBeneficioRepository : BaseRepository<AnexoBeneficio>, IAnexoBeneficioRepository
    {
        public AnexoBeneficioRepository(BeneficioContext beneficioContext)
            : base(beneficioContext)
        {
            _beneficioContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<AnexoBeneficio> GetAsyncByBeneficioId(int Id)
        {
            IQueryable<AnexoBeneficio> query = _beneficioContext.AnexoBeneficios
                .Include(c => c.Categoria)
                .AsNoTrackingWithIdentityResolution()
                .AsNoTracking()
                .Where(c => c.BeneficioId == Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<AnexoBeneficio> GetAsyncById(int Id)
        {
            IQueryable<AnexoBeneficio> query = _beneficioContext.AnexoBeneficios
                .Include(c => c.Categoria)
                .AsNoTrackingWithIdentityResolution()
                .AsNoTracking()
                .Where(c => c.Id == Id);

            return await query.FirstOrDefaultAsync();
        }



    }
}
