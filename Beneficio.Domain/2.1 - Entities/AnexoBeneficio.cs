using System;
using System.Collections.Generic;
using System.Text;

namespace Beneficio.Domain.Entities
{
    public class AnexoBeneficio
    {
        public int Id { get; set; }
        public int BeneficioId { get; set; }
        public BeneficioServidor Beneficio { get; set; }
        public string UrlAnexo { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
