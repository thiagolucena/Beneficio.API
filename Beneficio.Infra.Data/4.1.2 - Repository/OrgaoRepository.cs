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
    public class OrgaoRepository : BaseRepository<Orgao>, IOrgaoRepository
    {
        public OrgaoRepository(BeneficioContext beneficioContext)
            : base(beneficioContext)
        {
            _beneficioContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<Orgao>> GetAllOrgaoAsync()
        {
            IQueryable<Orgao> query = _beneficioContext.Orgaos
                .AsNoTrackingWithIdentityResolution()
                .AsNoTracking();
        
            return await query.ToListAsync();
        }
    }
}
