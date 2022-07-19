using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Operadoras.Domain;

namespace Operadoras.Persistence.Contratos
{
    public interface ITelefonePersist
    {
        Task<Telefone[]> GetAllTelefonesByNumAsync(string numero);

        Task<Telefone[]> GetAllTelefonesAsync();
        
        Task<Telefone> GetTelefoneByIdAsync(int telefoneId);
    }
}