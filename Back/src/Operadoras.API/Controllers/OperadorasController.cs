using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Operadoras.API.Models;
using Operadoras.API.Data;

namespace Operadoras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperadorasController : ControllerBase
    {

        

        public DataContext _context { get; }

        public OperadorasController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Operadora> Get()
        {
            return _context.Operadoras;
        }

        [HttpGet ("{id}")]
        public Operadora Get(int id)
        {
            return _context.Operadoras.FirstOrDefault(
                operadora => operadora.OperadoraId == id
                );
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
