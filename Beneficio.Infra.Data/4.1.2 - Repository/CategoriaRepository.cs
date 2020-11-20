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
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(BeneficioContext beneficioContext)
            : base(beneficioContext)
        {
            _beneficioContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<List<Categoria>> GetAllCategoriaAsync()
        {
            IQueryable<Categoria> query = _beneficioContext.Categorias
                .AsNoTrackingWithIdentityResolution()
                .AsNoTracking();

            return await query.ToListAsync();
        }
    }
}
