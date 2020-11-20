using System;
using System.Collections.Generic;
using System.Text;

namespace Beneficio.Domain.Entities
{
    public class MovimentacaoBeneficio
    {
        public int Id { get; set; }
        public int BeneficioId { get; set; }
        public BeneficioServidor Beneficio { get; set; }
        public DateTime DataTramitacao { get; set; }
        public int SetorOrigemId { get; set; }
        public Setor SetorOrigem { get; set; }
        public int SetorDestinoId { get; set; }
        public Setor SetorDestino { get; set; }
    }
}
