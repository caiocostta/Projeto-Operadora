using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Operadoras.Domain;
using Operadoras.Application.Contratos;
using Operadoras.Persistence.Contratos;

namespace Operadoras.Application
{
    public class OperadoraService : IOperadorasService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IOperadoraPersist _operadoraPersist;

        public OperadoraService(IGeralPersist _geralPersist, IOperadoraPersist _operadoraPersist)
        {
            this._operadoraPersist = _operadoraPersist;
            this._geralPersist = _geralPersist;
            
        }

        public async Task<Operadora> AddOperadoras(Operadora model)
        {
            try
            {
                _geralPersist.Add<Operadora>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _operadoraPersist.GetOperadoraByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message );
            }
        }

        public async Task<Operadora> UpdateOperadora(int operadoraId, Operadora model)
        {
            try
            {
                var operadora = await _operadoraPersist.GetOperadoraByIdAsync(operadoraId);
                if(operadora == null) return null;

                model.Id = operadora.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _operadoraPersist.GetOperadoraByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteOperadora(int operadoraId)
        {
            try
            {
                var operadora = await _operadoraPersist.GetOperadoraByIdAsync(operadoraId);
                if(operadora == null) throw new Exception("Evento para delete não encontrado.");
                
                _geralPersist.Delete<Operadora>(operadora);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Operadora[]> GetAllOperadorasAsync()
        {
           try
           {
                var operadoras = await _operadoraPersist.GetAllOperadorasAsync();
                if (operadoras == null) return null;

                return operadoras;
           }
           catch (Exception ex)
           {
            throw new Exception (ex.Message);
           } 
        }

        public async Task<Operadora[]> GetAllOperadorasByNomeAsync(string nome)
        {
            try
            {
                    var operadoras = await _operadoraPersist.GetAllOperadorasByNomeAsync(nome);
                    if (operadoras == null) return null;

                    return operadoras;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            } 
        }

        public async Task<Operadora> GetOperadoraByIdAsync(int operadoraId)
        {
            try
            {
                    var operadora = await _operadoraPersist.GetOperadoraByIdAsync(operadoraId);
                    if (operadora == null) return null;

                    return operadora;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            } 
        }
    }
}