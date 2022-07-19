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
    public class TelefonePersist : ITelefonePersist
    {
        private readonly OperadorasContext _context;

        public TelefonePersist(OperadorasContext _context)
        {
            this._context = _context;
            this._context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Telefone[]> GetAllTelefonesAsync()
        {
            IQueryable<Telefone> query = this._context.Telefones
                .Include(t => t.Operadora);

            query = query.OrderBy(t => t.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Telefone[]> GetAllTelefonesByNumAsync(string numero)
        {
            IQueryable<Telefone> query = this._context.Telefones
                .Include(t => t.Operadora);

            query = query.OrderBy(t => t.Id)
                        .Where(t => t.NumTelefone.Contains(numero));

            return await query.ToArrayAsync();
        }

        public async Task<Telefone> GetTelefoneByIdAsync(int telefoneId)
        {
            IQueryable<Telefone> query = this._context.Telefones
                .Include(o => o.Operadora);

            query = query.OrderBy(o => o.Id)
                        .Where(o => o.Id == telefoneId);

            return await query.FirstOrDefaultAsync();
        }
    }
}