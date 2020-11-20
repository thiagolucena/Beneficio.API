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
    public class MovimentacaoBeneficioRepository : BaseRepository<MovimentacaoBeneficio>, IMovimentacaoBeneficioRepository
    {
        public MovimentacaoBeneficioRepository(BeneficioContext beneficioContext)
            : base(beneficioContext)
        {
            _beneficioContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<MovimentacaoBeneficio> GetAsyncById(int Id)
        {
            IQueryable<MovimentacaoBeneficio> query = _beneficioContext.MovimentacaoBeneficios
                .Include(c => c.Beneficio)
                .Include(c => c.SetorOrigem)
                .Include(c => c.SetorDestino)
                .AsNoTrackingWithIdentityResolution()
                .AsNoTracking()
                .Where(c => c.Id == Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
