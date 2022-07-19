using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Operadoras.Domain
{
    public class Operadora
    {
        public int Id { get; set; }

        public string NomeOperadora { get; set; }

        public IEnumerable<Telefone> NumTelefones { get; set; }

        public string ObsOperadora { get; set; }
    }
}