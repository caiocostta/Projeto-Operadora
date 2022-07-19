using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Operadoras.Domain;
using Operadoras.Persistence.Contratos;

namespace Operadoras.Persistence.Contratos
{
    public interface IOperadoraPersist
    {
        Task<Operadora[]> GetAllOperadorasByNomeAsync(string nome);

        Task<Operadora[]> GetAllOperadorasAsync();
        
        Task<Operadora> GetOperadoraByIdAsync(int operadoraId);
    }
}