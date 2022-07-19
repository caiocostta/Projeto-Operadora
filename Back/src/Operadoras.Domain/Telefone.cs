using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Operadoras.Domain
{
    public class Telefone
    {
        public int Id { get; set; }

        public string NumTelefone { get; set; }

        public int OperadoraId { get; set; }

        public Operadora Operadora { get; set; }
    }
}