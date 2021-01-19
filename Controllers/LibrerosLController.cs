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
    public class LibrerosLController : ControllerBase
    {
        // GET: api/<LibrerosLController>
        [HttpGet]
        public IEnumerable<Libreros> Get()
        {
            var context = new bibliotecaContext();
            var librero = from b in context.Libreros
                                select new Libreros
                                {
                                    IdLibrero = b.IdLibrero,
                                    NombreLibrero = b.NombreLibrero
                                };
            return librero;

        }

        // GET api/<LibrerosLController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibrerosLController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LibrerosLController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibrerosLController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
