using System;
using System.Collections.Generic;
using System.Text;

namespace Beneficio.Domain.Entities
{
    public class BeneficioServidor
    {
        public BeneficioServidor()
        {
            LstAnexos = new List<AnexoBeneficio>();
        }

        public int Id { get; set; }
        public int ServidorId { get; set; }
        public Servidor Servidor { get; set; }
        public int OrgaoId { get; set; }
        public Orgao Orgao { get; set; }
        public int SetorId { get; set; }
        public Setor Setor { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<AnexoBeneficio> LstAnexos { get; set; }
        public List<MovimentacaoBeneficio> LstMovimentacoesBeneficio { get; set; }
    }
}
