using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Operadoras.API.Models
{
    public class Operadora
    {
        public int OperadoraId { get; set; }

        public string NomeOperadora { get; set; }

        public string NumTelefone { get; set; }
    }
}