using Microsoft.EntityFrameworkCore;
using Beneficio.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Beneficio.Domain.Entities;

namespace Beneficio.Infra.Data.Context
{
    public class BeneficioContext : DbContext
    {
        public BeneficioContext(DbContextOptions<BeneficioContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<BeneficioServidor> BeneficioServidores{ get; set; }
        public DbSet<AnexoBeneficio> AnexoBeneficios { get; set; }
        public DbSet<Orgao> Orgaos { get; set; }
        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<MovimentacaoBeneficio> MovimentacaoBeneficios { get; set; }
    }
}
