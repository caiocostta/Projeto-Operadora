using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Operadoras.Domain;
using Operadoras.Persistence.Contratos;
using Operadoras.Persistence.Contexto;

namespace Operadoras.Persistence
{
    public class OperadoraPersist : IOperadoraPersist
    {
        private readonly OperadorasContext _context;

        public OperadoraPersist(OperadorasContext _context)
        {
            this._context = _context;
            this._context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            
        }
        
        public async Task<Operadora[]> GetAllOperadorasAsync()
        {
            IQueryable<Operadora> query = this._context.Operadoras
                .Include(o => o.NumTelefones);

            query = query.OrderBy(o => o.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Operadora[]> GetAllOperadorasByNomeAsync(string nome)
        {
            IQueryable<Operadora> query = this._context.Operadoras
                .Include(o => o.NumTelefones);

            query = query.OrderBy(o => o.Id)
                        .Where(o => o.NomeOperadora.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Operadora> GetOperadoraByIdAsync(int operadoraId)
        {
            IQueryable<Operadora> query = this._context.Operadoras
                .Include(o => o.NumTelefones);

            query = query.OrderBy(o => o.Id)
                        .Where(o => o.Id == operadoraId);

            return await query.FirstOrDefaultAsync();
        }
    }
}