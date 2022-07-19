using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using Operadoras.Domain;
using Operadoras.Persistence;
using Operadoras.Persistence.Contexto;
using Operadoras.Application.Contratos;

namespace Operadoras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperadorasController : ControllerBase
    {
        private readonly IOperadorasService operadoraService;

        public OperadorasController(IOperadorasService operadoraService)
        {
            this.operadoraService = operadoraService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var operadoras = await operadoraService.GetAllOperadorasAsync();
                if (operadoras == null) return NotFound("Nenhuma operadora encontrada.");

                return Ok(operadoras);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar operadoras. Erro: {ex.Message}");
                throw;
            }
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var operadora = await operadoraService.GetOperadoraByIdAsync(id);
                if (operadora == null) return NotFound("Nenhuma operadora encontrada.");

                return Ok(operadora);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar operadoras. Erro: {ex.Message}");
                throw;
            }
        }

        [HttpGet ("/nome{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var operadora = await operadoraService.GetAllOperadorasByNomeAsync(nome);
                if (operadora == null) return NotFound("Nenhuma operadora encontrada.");

                return Ok(operadora);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar operadoras. Erro: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Operadora model)
        {
            try
            {
                var operadora = await operadoraService.AddOperadoras(model);
                if (operadora == null) return BadRequest("Erro ao tentar adicionar operadora.");

                return Ok(operadora);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar operadoras. Erro: {ex.Message}");
                throw;
            }
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> Put(int id, Operadora model)
        {
            try
            {
                var operadora = await operadoraService.UpdateOperadora(id, model);
                if (operadora == null) return BadRequest("Erro ao tentar atualizar operadora.");

                return Ok(operadora);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar operadoras. Erro: {ex.Message}");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(await operadoraService.DeleteOperadora(id))
                {
                    return Ok("Deletado");
                }
                else
                {
                    return BadRequest("Evento não deletado");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar apagar operadoras. Erro: {ex.Message}");
                throw;
            }
        }
    }
}
