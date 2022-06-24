using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Operadoras.API.Models;

namespace Operadoras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperadorasController : ControllerBase
    {

        public IEnumerable<Operadora> _operadora = new Operadora[]{
            new Operadora(){
                OperadoraId = 1,
                NomeOperadora = "America Net",
                NumTelefone = 1135001000
            },
            new Operadora(){
                OperadoraId = 2,
                NomeOperadora = "Algar Telecom",
                NumTelefone = 08009421212
            }
        };

        public OperadorasController()
        {
        }

        [HttpGet]
        public IEnumerable<Operadora> Get()
        {
            return _operadora;
        }

        [HttpGet ("{id}")]
        public IEnumerable<Operadora> Get(int id)
        {
            return _operadora.Where(operadora => operadora.OperadoraId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}
