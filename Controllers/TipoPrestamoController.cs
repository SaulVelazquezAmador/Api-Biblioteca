using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoBiblioteca.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPrestamoController : ControllerBase
    {
        // GET: api/<TipoPrestamoController>
        [HttpGet]
        public IEnumerable<TipoPrestamo> Get()
        {
            var context = new bibliotecaContext();
            var tipoprestamo = from b in context.TipoPrestamo
                                select new TipoPrestamo
                                {
                                    IdTipo = b.IdTipo,
                                    Tipo = b.Tipo
                                };
            return tipoprestamo;
        }

        // GET api/<TipoPrestamoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TipoPrestamoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TipoPrestamoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipoPrestamoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
