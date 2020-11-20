using System;
using System.Collections.Generic;
using System.Text;

namespace Beneficio.Domain.Entities
{
    public class Servidor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }

    }
}
