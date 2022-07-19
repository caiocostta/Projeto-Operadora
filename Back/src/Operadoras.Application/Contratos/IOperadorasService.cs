using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Operadoras.Domain;

namespace Operadoras.Application.Contratos
{
    public interface IOperadorasService
    {
        Task<Operadora> AddOperadoras(Operadora model);

        Task<Operadora> UpdateOperadora(int operadoraId, Operadora model);

        Task<bool> DeleteOperadora(int operadoraId);



        Task<Operadora[]> GetAllOperadorasByNomeAsync(string nome);

        Task<Operadora[]> GetAllOperadorasAsync();
        
        Task<Operadora> GetOperadoraByIdAsync(int operadoraId);
    }
}