using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Operadoras.Domain;

namespace Operadoras.Persistence.Contexto
{
    public class OperadorasContext : DbContext
    {
        public OperadorasContext(DbContextOptions<OperadorasContext> options) : base(options){}
        public DbSet<Operadora> Operadoras { get; set; }

        public DbSet<Telefone> Telefones { get; set; }
    }
}