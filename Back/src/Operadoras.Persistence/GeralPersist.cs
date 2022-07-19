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
    public class GeralPersist : IGeralPersist
    {
        private readonly OperadorasContext _context;

        public GeralPersist(OperadorasContext _context)
        {
            this._context = _context;
            
        }

        public void Add<T>(T entity) where T : class
        {
            this._context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this._context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this._context.Update(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            this._context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        
    }
}