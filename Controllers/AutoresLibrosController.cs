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
    public class AutoresLibrosController : ControllerBase
    {
        // GET: api/<AutoresLibrosController>
        [HttpGet]
        public IEnumerable<AutoresLibro> Get()
        {
            var context = new bibliotecaContext();
            var autoreslibros = from b in context.AutoresLibro
                                join s in context.Autor on b.RAutor equals s.IdAutor
                                select new AutoresLibro
                              {
                                  RAutor = b.RAutor,
                                  RIsbn = b.RIsbn
                              };

            return autoreslibros;
        }

        // GET api/<AutoresLibrosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AutoresLibrosController>
        [HttpPost]
        public void Post([FromBody] AutoresLibro value)
        {
        }

        // PUT api/<AutoresLibrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutoresLibrosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
